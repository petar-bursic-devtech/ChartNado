d3.csv("../SensitiveData/data.csv", function (d) {
    return {
        name: d["Name"],
        position: d["Employee role"],
        joinDate: d["joinDate"]
    };
}, function (error, rows) {
    generateGraph(rows);

});

function generateGraph(employeeData) {

    console.log(employeeData.length);

    var xScale;
    var yScale;
    var xAxis;
    var yAxis;

    function getDate(employeeJoinDate) {
        var fromDate = employeeJoinDate.split("/");
        var date = new Date(fromDate[2], fromDate[1] - 1, fromDate[0]);
        return date;
    }

    function getDateByKey(groupedEmployeesByDate) {
        var date = new Date(groupedEmployeesByDate["key"]);
        return date;
    }

    var grouped = d3.nest()
        .key(function (d) {
            var date = d3.time.month(getDate(d.joinDate));
            date.setMonth(date.getMonth() + 1);
            return date;
        })
        .entries(employeeData);


    //get number of employee at date of hire
    function getNumberOfEmployees(groupedEmployeesByDate) {

        var count = 0;

        var lastDateToConsider = getDateByKey(groupedEmployeesByDate);

        //get number of employee
        for (var i = 0; i < employeeData.length; i++) {
            var currentDate = getDate((employeeData[i].joinDate));

            if (lastDateToConsider.getTime() > d3.time.month(currentDate).getTime()) {
                count++;
            }
        }

        return count;
    }


    var margin = { top: 2, right: 20, bottom: 30, left: 50 },
        width = 1000,
        height = 500;


    // Scale the range of the data
    xScale = d3.time.scale().range([margin.left, width - margin.right]).domain(d3.extent(employeeData, function (d) { return getDate(d.joinDate); })),
        yScale = d3.scale.linear().range([height - margin.top, margin.bottom]).domain([0, employeeData.length]),

    // Define the axes
        xAxis = d3.svg.axis()
            .scale(xScale),
        yAxis = d3.svg.axis()
            .scale(yScale)
            .orient("left");


    //create svg
    var svg = d3.select("body")
        .append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform",
            "translate(" + margin.left + "," + margin.top + ")");


    //tip for employee
    var tip = d3.tip()
        .attr('class', 'd3-tip')
        .direction('s')
        .offset([0, 100])
        .html(function (groupedEmployeesByDate) {
            var date = getDateByKey(groupedEmployeesByDate);

            console.log(groupedEmployeesByDate["key"]);

            var numberOfEmployeesForMonth = getNumberOfEmployees(groupedEmployeesByDate);
            console.log(numberOfEmployeesForMonth);

            //in js month starts from 0

            var monthStats =
                "<p>Month: " + (date.getMonth() + 1) + "/" + date.getFullYear() + "<br>" +
                "Number of Employees: " + numberOfEmployeesForMonth + "</p><hr>" +
                "New employees:<br>";

            var newEmployees = "";

            for (var i = 0; i < groupedEmployeesByDate["values"].length; i++) {
                var employee = groupedEmployeesByDate["values"][i];

                newEmployees = newEmployees.concat(
                    "<p>Name: " + employee.name + " <br>" +
                    "Postion: " + employee.position + " " + "<br>" +
                    "Join Date: " + employee.joinDate + "</p>");
            }

            return monthStats.concat(newEmployees);
        });

    svg.call(tip);

    //define the lines
    var valueline = d3.svg.line()
        .x(function (d) { return xScale(getDateByKey(d)); })
        .y(function (d) { return yScale(getNumberOfEmployees(d)); });

    // Add the valueline path.
    svg.append("path")
        .attr("class", "line")
        .attr("d", valueline(grouped));

    // Add the X Axis
    svg.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + height + ")")
        .call(xAxis);

    // Add the Y Axis
    svg.append("g")
        .attr("class", "y axis")
        .call(yAxis);

    //Show and hide tip on mouse events
    svg.selectAll(".dot")
        .data(grouped)
        .enter().append("circle")
        .attr('class', 'datapoint')
        .attr('cx', function (d) { return xScale(getDateByKey(d)); })
        .attr('cy', function (d) { return yScale(getNumberOfEmployees(d)); })
        .attr('r', 6)
        .attr('fill', 'white')
        .attr('stroke', 'steelblue')
        .attr('stroke-width', '3')
        .on('mouseover', tip.show)
        .on('mouseout', tip.hide);
}