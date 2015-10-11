d3.csv('../SensitiveData/data.csv', function (d) {
    return {
        name: d['Name'],
        joinDate: d['joinDate'],
        leaveDate: d['leaveDate']
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
    var monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

    function getDate(employeeJoinDate) {
        var fromDate = employeeJoinDate.split('/');
        var date = new Date(fromDate[2], fromDate[0], fromDate[1]);
        return date;
    }

    function getDateByKey(groupedEmployeesByDate) {
        var date = new Date(groupedEmployeesByDate['key']);
        return date;
    }

    var grouped = d3.nest()
        .key(function (d) {
            var date = d3.time.month(getDate(d.joinDate));
            date.setMonth(date.getMonth() - 1);
            return date;
        })
        .entries(employeeData.sort(function (a, b) {
            return new Date(a.joinDate).getTime() - new Date(b.joinDate).getTime();
        }));


    //get number of employee at date of hire
    function getNumberOfEmployees(groupedEmployeesByDate) {


        var count = 0;

        var lastDateToConsider = getDateByKey(groupedEmployeesByDate);


        //increase for joinDate
        for (var i = 0; i < employeeData.length; i++) {
            var currentJoinDate = getDate((employeeData[i].joinDate));
            var month = currentJoinDate.getMonth();
            currentJoinDate.setMonth(month - 2);

            if (lastDateToConsider.getTime() > currentJoinDate.getTime()) {
                count++;
            }
        }

        //decrease for leaveDate
        for (var j = 0; j < employeeData.length; j++) {
            var currentLeaveDate = getDate((employeeData[j].leaveDate));
            var leaveMonth = currentLeaveDate.getMonth();
            currentLeaveDate.setMonth(leaveMonth - 2);

            if (lastDateToConsider.getTime() > currentLeaveDate.getTime()) {
                count--;
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
            .orient('left');


    //create svg
    var svg = d3.select('body')
        .append('svg')
        .attr('width', width + margin.left + margin.right)
        .attr('height', height + margin.top + margin.bottom)
        .append('g')
        .attr('transform',
            'translate(' + margin.left + ',' + margin.top + ')');


    //tip for employee
    var tip = d3.tip()
        .attr('class', 'd3-tip')
        .direction('s')
        .offset([0, 100])
        .html(function (groupedEmployeesByDate) {
            var date = getDateByKey(groupedEmployeesByDate);

            var numberOfEmployeesForMonth = getNumberOfEmployees(groupedEmployeesByDate);


            var monthStats =
                '<p>Month: ' + (monthNames[date.getMonth()]) + '/' + date.getFullYear() + '<br>' +
                    'Number of Employees: ' + numberOfEmployeesForMonth + '</p><hr>' +
                    'New employees:<br>';

            var newEmployees = '';

            //add employees which joined
            for (var i = 0; i < groupedEmployeesByDate['values'].length; i++) {

                var employee = groupedEmployeesByDate['values'][i];

                if (employee.joinDate) {
                    newEmployees = newEmployees.concat(
                        '<p>Name: ' + employee.name + ' <br>' +
                        'Join Date: ' + employee.joinDate + '</p>');
                }
            }

            monthStats = monthStats.concat(newEmployees);
            monthStats = monthStats.concat('<br>Employees left:<br>');
            var employeesLeft = '';

            //add employees which left
            for (var j = 0; j < employeeData.length; j++) {

                var employeeLeft = employeeData[j];

                if (employeeLeft.leaveDate) {
                    var employeeLeftDate = getDate(employeeLeft.leaveDate);

                    if ((employeeLeftDate.getMonth() - 1) === date.getMonth()
                        && (employeeLeftDate.getFullYear() === date.getFullYear())) {
                        employeesLeft = employeesLeft.concat(
                            '<p>Name: ' + employeeLeft.name + ' <br>' +
                            'Leave Date: ' + employeeLeft.leaveDate + '</p>');
                    }
                }

            }

            return monthStats.concat(employeesLeft);
        });

    svg.call(tip);

    //define the lines
    var valueline = d3.svg.line()
        .x(function (d) { return xScale(getDateByKey(d)); })
        .y(function (d) { return yScale(getNumberOfEmployees(d)); });

    // Add the valueline path.
    svg.append('path')
        .attr('class', 'line')
        .attr('d', valueline(grouped));

    // Add the X Axis
    svg.append('g')
        .attr('class', 'x axis')
        .attr('transform', 'translate(0,' + height + ')')
        .call(xAxis);

    // Add the Y Axis
    svg.append('g')
        .attr('class', 'y axis')
        .call(yAxis);

    //Show and hide tip on mouse events
    svg.selectAll('.dot')
        .data(grouped)
        .enter().append('circle')
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