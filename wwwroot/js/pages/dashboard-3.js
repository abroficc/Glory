/**
 * Template Name: INSPINIA - Multipurpose Admin & Dashboard Template
 * By (Author): WebAppLayers
 * Module/App (File Name): Dashboard v.3
 * Version: 4.2.0
 */

// Make sure all Bootstrap dropdowns are properly initialized
document.addEventListener('DOMContentLoaded', function() {
    // Re-initialize all dropdowns on this page
    document.querySelectorAll('[data-bs-toggle="dropdown"]').forEach((el) => {
        // Check if dropdown is already initialized
        if (!bootstrap.Dropdown.getInstance(el)) {
            new bootstrap.Dropdown(el);
        }
    });

    // Add this to fix any potential issues with all header dropdowns (notification, message and user profile)
    document.querySelectorAll('.topbar-item .dropdown').forEach((dropdown) => {
        const dropdownToggle = dropdown.querySelector('.dropdown-toggle');
        if (dropdownToggle) {
            // Remove any existing click event listeners first to avoid duplicates
            dropdownToggle.removeEventListener('click', handleDropdownClick);
            dropdownToggle.addEventListener('click', handleDropdownClick);
        }
    });
    
    // Specifically target the user profile dropdown in the nav-user class
    const userProfileToggle = document.querySelector('.nav-user .dropdown-toggle');
    if (userProfileToggle) {
        // Remove any existing click event listeners first to avoid duplicates
        userProfileToggle.removeEventListener('click', handleDropdownClick);
        userProfileToggle.addEventListener('click', handleDropdownClick);
    }
    
    function handleDropdownClick(e) {
        e.preventDefault();
        e.stopPropagation();
        
        const dropdownInstance = bootstrap.Dropdown.getInstance(this);
        if (dropdownInstance) {
            dropdownInstance.toggle();
        } else {
            new bootstrap.Dropdown(this).toggle();
        }
    }
    
    // Initialize water dashboard charts
    initializeWaterDashboard();
});

function initializeWaterDashboard() {
    // Water consumption chart
    new CustomApexChart({
        selector: '#water-consumption-chart',
        options: () => ({
            chart: {
                height: 326,
                type: 'area',
                toolbar: {show: false}
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                width: 2,
                curve: 'smooth'
            },
            colors: ['#1ab394', '#3498db'],
            series: [
                {
                    name: 'استهلاك المياه (م³)',
                    data: [12.2, 13.1, 11.8, 12.5, 13.0, 12.8, 13.4, 14.2, 13.9, 13.6, 14.1, 13.8, 14.5, 14.0, 13.7, 13.2, 12.9, 12.6, 12.4]
                },
                {
                    name: 'ضغط المياه (psi)',
                    data: [40.5, 41.2, 39.8, 40.8, 42.1, 41.7, 42.3, 43.0, 42.6, 42.2, 42.8, 42.4, 43.1, 42.7, 42.0, 41.5, 41.0, 40.7, 40.3]
                }
            ],
            legend: {
                offsetY: 5,
            },
            xaxis: {
                categories: ["", "6 AM", "7 AM", "8 AM", "9 AM", "10 AM", "11 AM",
                    "12 PM", "1 PM", "2 PM", "3 PM", "4 PM", "5 PM", "6 PM",
                    "7 PM", "8 PM", "9 PM", "10 PM", "11 PM"],
                axisBorder: {show: false},
                axisTicks: {show: false},
                tickAmount: 6,
                labels: {
                    style: {
                        fontSize: "12px"
                    }
                }
            },
            tooltip: {
                shared: true,
                y: {
                    formatter: function (val, {seriesIndex}) {
                        if (seriesIndex === 0) {
                            return val + " م³";
                        } else if (seriesIndex === 1) {
                            return val + " psi";
                        }
                        return val;
                    }
                }
            },
            fill: {
                type: "gradient",
                gradient: {
                    shadeIntensity: 1,
                    opacityFrom: 0.4,
                    opacityTo: 0.2,
                    stops: [15, 120, 100]
                }
            },
            grid: {
                borderColor: ['#e5e9f2'],
                padding: {
                    bottom: 5
                }
            }
        })
    });

    // Panels status chart
    new CustomApexChart({
        selector: '#panels-status-chart',
        options: () => ({
            chart: {
                height: 208,
                type: 'donut',
                toolbar: {
                    show: false
                }
            },
            dataLabels: {
                enabled: false
            },
            series: [18, 4, 2, 4], // Active, Warning, Error, Offline
            colors: ['#10c469', '#ffbd4a', '#ff5b5b', '#5b69bc'],
            labels: ['نشط', 'تحذير', 'خطأ', 'غير متصل'],
            legend: {
                show: true,
                position: 'bottom',
                horizontalAlign: 'center'
            },
            tooltip: {
                y: {
                    formatter: function(val) {
                        return val + " لوحة";
                    }
                }
            }
        })
    });

    // Water quality chart
    new CustomApexChart({
        selector: '#water-quality-chart',
        options: () => ({
            series: [{
                type: 'column',
                data: [[0, 85], [1, 87], [2, 86], [3, 88], [4, 87], [5, 89], [6, 88], [7, 87], [8, 86], [9, 88], [10, 87], [11, 89], [12, 88], [13, 87], [14, 86]]
            }, {
                type: 'column',
                data: [[0, 92], [1, 91], [2, 93], [3, 90], [4, 92], [5, 91], [6, 93], [7, 92], [8, 91], [9, 90], [10, 92], [11, 91], [12, 93], [13, 92], [14, 91]]
            }],
            chart: {
                height: 60,
                width: 205,
                parentHeightOffset: 0,
                stacked: true,
                sparkline: {
                    enabled: true
                }
            },
            states: {
                hover: {
                    filter: {
                        type: 'none'
                    }
                },
                active: {
                    filter: {
                        type: 'none'
                    }
                }
            },
            colors: ['#1ab394', '#e5e9f2'],
            plotOptions: {
                bar: {
                    columnWidth: '60%'
                },
            },
            stroke: {
                curve: 'straight',
                lineCap: 'square'
            },
            tooltip: {
                enabled: false,
                onDatasetHover: {
                    highlightDataSeries: false,
                },
                x: {
                    show: false,
                },
            }
        })
    });

    // Distribution centers chart
    new CustomApexChart({
        selector: '#distribution-centers-chart',
        options: () => ({
            chart: {
                type: 'bar',
                height: 60,
                sparkline: {
                    enabled: true
                },
            },
            stroke: {
                curve: 'smooth',
                width: 1.5
            },
            fill: {
                opacity: 1,
                gradient: {
                    shade: '#1ab394',
                    type: "horizontal",
                    shadeIntensity: 0.5,
                    inverseColors: true,
                    opacityFrom: 0.1,
                    opacityTo: 0.2,
                    stops: [0, 80, 100],
                    colorStops: []
                },
            },
            series: [{
                data: [98.2, 96.8, 95.4, 97.1, 94.6, 96.3, 97.8, 95.9, 96.7, 97.3]
            }],
            yaxis: {
                min: 90
            },
            colors: ['#1ab394'],
            tooltip: {
                enabled: false,
            }
        })
    });

    // Update water quality index
    updateWaterQualityIndex();
}

function updateWaterQualityIndex() {
    // Set initial water quality index
    document.getElementById("water-quality-index").textContent = "87.5";
}

// Function to generate a random number between min and max
function getRandomNumber(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}