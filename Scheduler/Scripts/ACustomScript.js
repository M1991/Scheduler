﻿(function ($) {
    $(document).ready(function () {

        // page is now ready, initialize the calendar...
        var sourceFullView = { url: '/Events/GetCalDispEvents/' };
        var sourceSummaryView = { url: '/Home/GetDiarySummary/' };
        var CalLoading = true;

     /*   $("#divHtml").dialog({
            autoOpen: false,
            //maxWidth: 850,
            //maxHeight: 650,
            width: 450,
            height: 250,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            },
            show: {
                effect: "blind",
                duration: 1000
            },
            hide: {
                effect: "explode",
                duration: 1000
            }
        });
              
        $('.progressbar').each(function () {
            var $el = $(this);
            $el.progressbar({
                value: $el.data("progress-value")
            });
        });*/
     /* 
       $('#fromTime').timepicker({
            // dateFormat:'yy-mm-dd',
            timeFormat: 'H:i:s',
            'disableTimeRanges': [
                ['1pm', '1:30pm'],
            ],
            'minTime': '09:00am',
            'maxTime': '06:00pm',
            'showDuration': true
        });
        $('#toTime').timepicker({
            twentyFour: false,
            'timeFormat': 'H:i:s',
            'minTime': '09:00am',
            'maxTime': '06:00pm',
            'showDuration': true
        });
         //  $('#toTime').wickedpicker();
        //   var options = {
        //hh:mm 24 hour format only, defaults to current time
            twentyFour: true,  //Display 24 hour format, defaults to false
            upArrow: 'wickedpicker__controls__control-up',  //The up arrow class selector to use, for custom CSS
            downArrow: 'wickedpicker__controls__control-down', //The down arrow class selector to use, for custom CSS
            close: 'wickedpicker__close', //The close class selector to use, for custom CSS
            hoverState: 'hover-state', //The hover state class to use, for custom CSS
            title: 'Timepicker', //The Wickedpicker's title,
            showSeconds: true, //Whether or not to show seconds,
            timeSeparator: ' : ', // The string to put in between hours and minutes (and seconds)
            secondsInterval: 1, //Change interval for seconds, defaults to 1,
            minutesInterval: 1, //Change interval for minutes, defaults to 1
            beforeShow: null, //A function to be called before the Wickedpicker is shown
            afterShow: null, //A function to be called after the Wickedpicker is closed/hidden
            show: null, //A function to be called when the Wickedpicker is shown  */
        //     clearable: false, //Make the picker's input clearable (has clickable "x")
        //  };
        //  $('#toTime').wickedpicker(options);
       
        /// Date picker drop-down
        $(function () {
            /// Include holidays date wise
            var holiday = [[12, 25, 2018], [1, 1, 2018], [1, 26, 2018], [8, 15, 2018]];
           // var holiday = "/Holidays/GetHolidays",
            var dateFormat = "yy-mm-dd",
                from = $("#from")
                    .datepicker({
                        beforeShowDay: nonWorkingDays,
                        dateFormat: "yy-mm-dd",
                        defaultDate: "+1d",
                        changeMonth: true,
                        changeYear: true,
                        numberOfMonths: 1,
                        minDate: 0,
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                to = $("#to").datepicker({
                    beforeShowDay: nonWorkingDays,
                    dateFormat: "yy-mm-dd",
                    defaultDate: "+1d",
                    changeMonth: true,
                    changeYear: true,
                    numberOfMonths: 1
                })
                    .on("change", function () {
                        from.datepicker("option", "maxDate", getDate(this));
                    });
            $("#dtCrtd").datepicker({
                beforeShowDay: nonWorkingDays,
                dateFormat: "yy-mm-dd",
                defaultDate: "+1d",
                changeMonth: true,
                numberOfMonths: 1,
                minDate:0
            });

            function getDate(element) {
                var date;
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }
                return date;
            }

            function nonWorkingDays(date) {

                var day = date.getDay(), Sunday = 0, Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6;
                var week = 0 | date.getDate() / 7 //get the week

                //check if it's second week or fourth week
                if (week == 0 || week == 2) {
                    if (day == 6) { //check for satruday
                        return [false];
                    }
                }

                //check for sunday
                if (day == 0) {
                    return [false];
                }

                //check for holidays
                for (i = 0; i < holiday.length; i++) {
                    if (date.getMonth() == holiday[i][0] - 1 &&
                        date.getDate() == holiday[i][1] &&
                        date.getFullYear() == holiday[i][2]) {
                        return [false];
                    }
                }
                return [true];
            }

        });

        /*   $(function () {

               $(".datepicker").datepicker({
                   dateFormat: "yy-mm-dd",
                   showStatus: true,
                   showWeeks: true,
                   minDate:0,
               });
               $("#fadeIn").on("change", function () {
                   $("#datepicker").datepicker("option", "minDate", date);
               });
           }); */

        $('#calendr').fullCalendar({
            customButtons: {
                addAnEvent: {
                    text: 'Add Order',
                    click: function () {
                        //Not working   
                      //  $("#divHtml").dialog("open");
                    $('#myModal').modal();

                        // $("#opener").on("click", function () {
                        //      $("#dialog").dialog("open");
                        // });
                    }
                }
            },
            currentTimeMarker: {
                updateInterval: 100,
            },
            minTime: '09:00:00',
            maxTime: '18:00:00',           
            displayEventTime: false,
            eventLimit: true,
            selectable: true,           
            dayRender: function (date, cell) {
                /// Check for holidays and weekends
                // if (date == ) {
                //      $(cell).addClass('disabled');
                //  }
            },
            overlap: false,
            header: {
                left: 'prev,next today,addAnEvent',
                center: 'title',
                right: 'month,agendaWeek,agendaDay,listMonth'
            },
            defaultView: 'month',
            editable: true,    /// Set to false if events are not dragable
            eventConstraint: {
                dow: [1, 2, 3, 4, 5, 6],
                start: moment().format('YYYY-MM-DD 09:00:00'),
                end: '18:00' // Event ends at 6pm everyday
            },
            businessHours: {
                // days of week. an array of 0 zero-based day of week integers (0=Sunday)
                dow: [1, 2, 3, 4, 5, 6], // Monday - Saturday
                start: moment().format('HH:mm'), /* Current Hour/Minute 24H format */
                end: '18:00', // an end time (6pm in this example)
            },
            eventRender: function (event, element) {
              //eventElement.addClass('progressbar');
               // var totNo = document.getElementById("#noOfDays").value;
                $(element).progressbar({
                   ///value: event.value                    
                    value: event.value,
                    
                });
                
                //element.qtip({
                //    content: event.description
                //});
                element.attr('title', event.tooltip);
               /* if (event.title == "Booked") {                    
                    console.log(event.backgroundColor)                    
                    //document.getElementByClassName("a.fc-content").css('background-color', 'green');
                   // this.event.progressbar
                   // alert("Found you");
                }*/
                //element.attr("categories")

                var dataHoje = new Date();
               // if(event.start < dataHoje && event.end > dataHoje) {
                    if (event.value >= 90) {
                    //event.color = "#FFB347"; //Em andamento //FFB347 #C0392B
                        element.css('background-color', '#77DD77');
                    /*<div class="progressbar" data-progress-value="33"> */
                } else if (event.start < dataHoje && event.end < dataHoje) {
                    //event.color = "#77DD77"; //Concluído OK
                        element.css('background-color', '#C0392B'); //Now color
                } else if (event.start > dataHoje && event.end > dataHoje) {
                    //event.color = "#AEC6CF"; //Não iniciado
                    element.css('background-color', '#AEC6CF');
                }
            },
           // events: '/Events/GetCalDispEvents/', 
            eventSources: [{
                url: $('#calendr').data('url'),
                type: 'GET',
                error: function () {
                    alert('there was an error while fetching events!');
                }
            }],

         /*   eventSources: [{
                url: '@Url.Action("GetCalDispEvents", "Events")',
                type: 'GET',
                error: function () {
                    alert('there was an error while fetching events!');
                }
            }],
            eventSources: [
                {
                    url: '@Url.Action("GetCalDispEvents")',
                    type: 'GET',
                    backgroundColor: 'red',
                    success: function (doc) {
                        events.push(doc); 
                        alert('we got the events!');
                    },
                    error: function () {
                        alert('there was an error while fetching events!');
                    },
                }],*/
          /*   events:
               [{
                   title: 'Booked',
                   start: '2017-12-07T15:30:00',
                   allDay: false,
                   color: 'Blue',
                   className: 'progressbar',
                   value: '45',
               },{
                    title: 'Example Event Addition',
                    start: '2017-12-13T14:30:00',
                    allDay: false,
                    color: 'Red',
               }, {
                   title: 'Example Event 2',
                   start: '2017-12-06T09:30:00',
                   allDay: false,
                   color:'Green',
                   }
              ], */

            /// Event click opens a page and display the results in calendar
            eventClick: function (event, jsEvent, view) {
                alert('S.O.No: ' + event.title + '\nStart: ' + moment(event.start).format("DD-MM-YYYY") + '\nEnd: ' + moment(event.end).format("DD-MM-YYYY"));
                var baseUrl = 'http://localhost:61714/Events';
               // var baseUrl = 'http: //localhost/Scheduler/Events';
               //window.location = '@Url.Action("Details", "Events", new { id = calEvent.id})';
               // window.location.href = '@Url.Action("Details", "Events")?id=' + event.id;
                location.href = baseUrl + '/Details?id=' + event.id;

                // change the border color just for fun
                $(this).css('border-color', 'red');

             },

            /*eventClick: function (calEvent, jsEvent, view) {
                alert('You clicked on event id: ' + calEvent.id
                    + "\nSpecial ID: " + calEvent.allDay
                    + "\nAnd the title is: " + calEvent.start);
            },
            */

            eventMouseover: function (data, event, view)
            {
                // Change alert to SomeMouseOver, details of events
                //alert(date);      
                tooltip = '<div class="tooltiptopicevent" style="width:auto;height:auto;background:#feb811;position:absolute;z-index:10001;padding:10px 10px 10px 10px ;  line-height: 200%;">' + 'SO.No: ' + ': ' + data.title + '</br>' + 'Progress: ' + ': ' + data.value + '%' +'</br>'+ 'Total Part.Nos: ' + ': ' + data.ptno + '</br>'+ '</div>';

                $("body").append(tooltip);
                $(this).mouseover(function (e) {
                    $(this).css('z-index', 10000);
                    $('.tooltiptopicevent').fadeIn('500');
                    $('.tooltiptopicevent').fadeTo('10', 1.9);
                }).mousemove(function (e) {
                    $('.tooltiptopicevent').css('top', e.pageY + 10);
                    $('.tooltiptopicevent').css('left', e.pageX + 20);
                });
            },
            eventMouseout: function (data, event, view) {
                $(this).css('z-index', 8);

                $('.tooltiptopicevent').remove();

            },
            //dayClick: function () {
            //    tooltip.hide()
            //},
            eventResizeStart: function () {
                tooltip.hide()
            },
            eventDragStart: function () {
                tooltip.hide()
            },
            viewDisplay: function () {
                tooltip.hide()
            },

            dayClick: function (date, allDay, jsEvent, view) {
                //alert('Clicked on: ' + date.format());
                //Will get the list of events for that day
              //   tooltip.hide()
                var view = $('#calendar').fullCalendar('getView');
                if (view.name == 'month' || view.name == 'agendaWeek') {
                    $('#calendar').fullCalendar('changeView', 'agendaDay');
                    $('#calendar').fullCalendar('gotoDate', date);
                }
                // $('#eventTitle').val("");
                // $('#eventDate').val($.fullCalendar.formatDate(date, 'dd/MM/yyyy'));
                // $('#eventTime').val($.fullCalendar.formatDate(date, 'HH:mm'));
                // ShowEventPopup(date);
            },

            viewRender: function (view, element) {
                if (!CalLoading) {
                    if (view.name == 'month') {
                        $('#calendar').fullCalendar('removeEventSource', sourceFullView);
                        $('#calendar').fullCalendar('removeEvents');
                        $('#calendar').fullCalendar('addEventSource', sourceSummaryView);
                    }
                    else {
                        $('#calendar').fullCalendar('removeEventSource', sourceSummaryView);
                        $('#calendar').fullCalendar('removeEvents');
                        $('#calendar').fullCalendar('addEventSource', sourceFullView);
                    }
                }
            }
            /// SET callLoading to FALSE here

            // put your options and callbacks here
        })

    });
    
    function ShowEventPopup(date) {
        ClearPopupFormValues();
        $('#popupEventForm').show();
        $('#eventTitle').focus();
    }

    function ClearPopupFormValues() {
        $('#eventID').val("");
        $('#eventTitle').val("");
        $('#eventDateTime').val("");
        $('#eventDuration').val("");
    }

    function UpdateEvent(EventID, EventStart, EventEnd) {

        var dataRow = {
            'ID': EventID,
            'NewEventStart': EventStart,
            'NewEventEnd': EventEnd
        }

        $.ajax({
            type: 'POST',
          //  url: "/Events/Create",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dataRow)
        });
    }
    $('.fc-AddCustomButton-button').append('< i class="glyphicon glyphicon-plus" ></i>');
})(jQuery);





/*
(function ($) {
    $(document).ready(function () {

      });
})(jQuery);
*/