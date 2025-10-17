// Financial Voucher Pages Filters Functionality
$(document).ready(function() {
    // Initialize DataTable for the balance deduction voucher table (matching Deduction Voucher page)
    var deductionTable;
    if (!$.fn.DataTable.isDataTable('#myTable')) {
        deductionTable = $('#myTable').DataTable({
            responsive: true,
            paging: true,
            searching: true,
            info: true,
            pageLength: 10,
            lengthMenu: [5, 10, 25, 50],
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.8/i18n/ar.json"
            },
            columnDefs: [
                { orderable: false, targets: [0, -1] } // Disable sorting on checkbox and actions columns
            ],
            order: [[1, 'asc']], // Sort by ID column by default (second column, index 1)
            dom: '<"top"f>rt<"bottom"lip><"clear">' // Same DOM structure as Customer Journal
        });
    } else {
        deductionTable = $('#myTable').DataTable();
    }
    
    // Initialize DataTable for the customers table (matching Customer Journal page)
    var customersTable;
    if (!$.fn.DataTable.isDataTable('#customers-table')) {
        customersTable = $('#customers-table').DataTable({
            responsive: true,
            paging: true,
            searching: true,
            info: true,
            pageLength: 10,
            lengthMenu: [5, 10, 25, 50],
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.8/i18n/ar.json"
            },
            columnDefs: [
                { orderable: false, targets: [0, 11] } // Disable sorting on checkbox and actions columns
            ],
            order: [[1, 'asc']], // Sort by ID column by default
            dom: '<"top"f>rt<"bottom"lip><"clear">' // Same DOM structure as Deduction Voucher
        });
    } else {
        customersTable = $('#customers-table').DataTable();
    }
    
    // Initialize DataTable for Pricing Groups table
    var pricingGroupsTable;
    if ($('#categoriesTable').length > 0 && !$.fn.DataTable.isDataTable('#categoriesTable')) {
        pricingGroupsTable = $('#categoriesTable').DataTable({
            responsive: true,
            paging: true,
            searching: true,
            info: true,
            pageLength: 10,
            lengthMenu: [5, 10, 25, 50],
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.8/i18n/ar.json"
            },
            columnDefs: [
                { orderable: false, targets: [0, -1] } // Disable sorting on checkbox and actions columns
            ],
            order: [[1, 'asc']], // Sort by ID column by default
            dom: '<"top"f>rt<"bottom"lip><"clear">'
        });
    } else if ($('#categoriesTable').length > 0) {
        pricingGroupsTable = $('#categoriesTable').DataTable();
    }

    // Function to initialize Select2 with common options
    function initSelect2(selector, placeholder) {
        $(selector).select2({
            dir: "rtl",
            width: "100%",
            placeholder: placeholder,
            allowClear: true,
            language: {
                noResults: function () {
                    return "لا توجد نتائج";
                }
            }
        });
    }

    // Function to initialize Select2 with AJAX for large datasets
    function initSelect2Ajax(selector, placeholder, apiUrl) {
        $(selector).select2({
            dir: "rtl",
            width: "100%",
            placeholder: placeholder,
            allowClear: true,
            minimumInputLength: 2,
            ajax: {
                url: apiUrl,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        q: params.term, // search term
                        page: params.page || 1
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    
                    return {
                        results: data.results,
                        pagination: {
                            more: (params.page * 10) < data.total_count
                        }
                    };
                },
                cache: true
            },
            language: {
                noResults: function () {
                    return "لا توجد نتائج";
                },
                searching: function() {
                    return "جاري البحث...";
                },
                inputTooShort: function() {
                    return "الرجاء إدخال حرفين أو أكثر للبحث";
                }
            }
        });
    }

    // Initialize Select2 for all select elements on Customer Journal page
    if ($('#customers-table').length > 0) {
        // For smaller datasets, use static options
        initSelect2('#filter-accounting-sources', "اختر مصدر حساب...");
        initSelect2('#filter-all-employees', "اختر موظف...");
        initSelect2('#filter-currencies', "اختر عملة...");
        initSelect2('#filter-all-groups', "اختر مجموعة...");
        initSelect2('#filter-customer-type', "اختر نوع عميل...");
        
        // For larger datasets like customers, use AJAX
        // initSelect2Ajax('#filter-customers', "ابحث عن عميل...", '/api/customers/search');
        
        // For now, using static options for customers as well
        initSelect2('#filter-customers', "ابحث عن عميل...");
    }

    // Handle filter toggle button
    $('#toggleFilters').on('click', function () {
        var filterSection = $('#filterSection');
        var icon = $(this).find('i');
        var textSpan = $('#toggleFiltersText');

        if (filterSection.is(':visible')) {
            // Hide the filter section with slide animation
            filterSection.slideUp();
            icon.removeClass('ti-filter-off').addClass('ti-filter');
            textSpan.text('إظهار الفلترة');
        } else {
            // Show the filter section with slide animation
            filterSection.slideDown();
            icon.removeClass('ti-filter').addClass('ti-filter-off');
            textSpan.text('إخفاء الفلترة');
        }
    });

    // Handle apply filters button
    $('#applyFilters').on('click', function () {
        // Check which page we're on and apply filters to the appropriate table
        if ($('#customers-table').length > 0 && typeof customersTable !== 'undefined') {
            // Customer Journal page - apply filters directly to DataTable
            let customer = $('#filter-customers option:selected').text();
            let statement = $('#filter-statement').val();
            let dateFrom = $('#filter-date-from').val();
            let dateTo = $('#filter-date-to').val();
            let accountingSource = $('#filter-accounting-sources').val();
            let employee = $('#filter-all-employees').val();
            let currency = $('#filter-currencies').val();
            let group = $('#filter-all-groups').val();
            let customerType = $('#filter-customer-type').val();
            let year = $('#filter-year').val();
            let period = $('#filter-period').val();
            
            // Clear any existing custom search functions
            $.fn.dataTable.ext.search = [];
            
            // Apply filters to specific columns
            // Column index: 0=checkbox, 1=id, 2=account, 3=customer, 4=credit, 5=debit, 6=difference, 7=date, 8=employee, 9=source, 10=currency, 11=actions
            customersTable.column(3).search(customer && customer !== "كل العملاء" ? customer : ''); // Customer column
            customersTable.column(6).search(statement ? statement : ''); // Statement/description column
            
            // Employee filter
            customersTable.column(8).search(employee && employee !== "" ? employee : '');
            
            // Accounting source filter
            customersTable.column(9).search(accountingSource && accountingSource !== "" ? accountingSource : '');
            
            // Currency filter
            customersTable.column(10).search(currency && currency !== "" ? currency : '');
            
            // Date range filtering using custom search function
            if (dateFrom || dateTo) {
                $.fn.dataTable.ext.search.push(function(settings, data, dataIndex) {
                    let date = data[7]; // Date column (index 7)
                    if (!date) return true;
                    
                    // Convert date strings to Date objects for comparison
                    let dateValue = new Date(date);
                    let fromDate = dateFrom ? new Date(dateFrom) : null;
                    let toDate = dateTo ? new Date(dateTo) : null;
                    
                    if (fromDate && dateValue < fromDate) return false;
                    if (toDate && dateValue > toDate) return false;
                    return true;
                });
            }
            
            customersTable.draw();
        } else if ($('#myTable').length > 0 && typeof deductionTable !== 'undefined') {
            // Account Transfers page - apply filters directly to DataTable
            // Note: The actual Account Transfers table has 11 columns:
            // 0=Checkbox, 1=ID, 2=From Account, 3=To Account, 4=Amount, 5=Currency, 6=Statement, 7=Date, 8=Add Date, 9=Employee ID, 10=Actions
            
            // Get filter values
            let id = $('#filter-id').val();
            let fromAccount = $('#filter-from-account').val();
            let toAccount = $('#filter-to-account').val();
            let amount = $('#filter-amount').val();
            let currency = $('#filter-currency').val();
            let statement = $('#filter-statement').val();
            let dateFrom = $('#filter-date-from').val();
            let dateTo = $('#filter-date-to').val();
            let employeeId = $('#filter-employee').val();
            
            // Clear any existing custom search functions
            $.fn.dataTable.ext.search = [];
            
            // Apply filters to specific columns
            deductionTable.column(1).search(id ? id : ''); // ID column
            deductionTable.column(2).search(fromAccount ? fromAccount : ''); // From Account column
            deductionTable.column(3).search(toAccount ? toAccount : ''); // To Account column
            deductionTable.column(4).search(amount ? amount : ''); // Amount column
            deductionTable.column(5).search(currency ? currency : ''); // Currency column
            deductionTable.column(6).search(statement ? statement : ''); // Statement column
            
            // Employee ID filter
            deductionTable.column(9).search(employeeId ? employeeId : ''); // Employee ID column
            
            // Date range filtering using custom search function
            if (dateFrom || dateTo) {
                $.fn.dataTable.ext.search.push(function(settings, data, dataIndex) {
                    let dateValue = data[7]; // Date column (index 7)
                    if (!dateValue) return true;
                    
                    // Convert date strings to Date objects for comparison
                    let dateVal = new Date(dateValue);
                    let fromDate = dateFrom ? new Date(dateFrom) : null;
                    let toDate = dateTo ? new Date(dateTo) : null;
                    
                    if (fromDate && dateVal < fromDate) return false;
                    if (toDate && dateVal > toDate) return false;
                    return true;
                });
            }
            
            deductionTable.draw();
        } else if ($('#categoriesTable').length > 0 && typeof pricingGroupsTable !== 'undefined') {
            // Pricing Groups page - apply filters directly to DataTable
            // Get filter values
            let id = $('#filter-id').val();
            let groupName = $('#filter-group-name').val();
            let mobile = $('#filter-mobile').val();
            let you = $('#filter-you').val();
            let youPackages = $('#filter-you-packages').val();
            let safafon = $('#filter-safafon').val();
            let wifi = $('#filter-wifi').val();
            let mobileWholesale = $('#filter-mobile-wholesale').val();
            let youWholesale = $('#filter-you-wholesale').val();
            let safafonWholesale = $('#filter-safafon-wholesale').val();
            let internet = $('#filter-internet').val();
            let landline = $('#filter-landline').val();
            let mobileRecharge = $('#filter-mobile-recharge').val();
            let moneyTransfer = $('#filter-money-transfer').val();
            
            // Clear any existing custom search functions
            $.fn.dataTable.ext.search = [];
            
            // Apply filters to specific columns
            pricingGroupsTable.column(1).search(id ? id : ''); // ID column
            pricingGroupsTable.column(2).search(groupName ? groupName : ''); // Group Name column
            pricingGroupsTable.column(3).search(mobile ? mobile : ''); // Mobile column
            pricingGroupsTable.column(4).search(you ? you : ''); // YOU column
            pricingGroupsTable.column(5).search(youPackages ? youPackages : ''); // YOU Packages column
            pricingGroupsTable.column(6).search(safafon ? safafon : ''); // Safafon column
            pricingGroupsTable.column(7).search(wifi ? wifi : ''); // WiFi column
            pricingGroupsTable.column(8).search(mobileWholesale ? mobileWholesale : ''); // Mobile Wholesale column
            pricingGroupsTable.column(9).search(youWholesale ? youWholesale : ''); // YOU Wholesale column
            pricingGroupsTable.column(10).search(safafonWholesale ? safafonWholesale : ''); // Safafon Wholesale column
            pricingGroupsTable.column(11).search(internet ? internet : ''); // Internet column
            pricingGroupsTable.column(12).search(landline ? landline : ''); // Landline column
            pricingGroupsTable.column(13).search(mobileRecharge ? mobileRecharge : ''); // Mobile Recharge column
            pricingGroupsTable.column(14).search(moneyTransfer ? moneyTransfer : ''); // Money Transfer column
            
            pricingGroupsTable.draw();
        }
    });

    // Handle reset filters button
    $('#resetFilters').on('click', function () {
        // Check which page we're on and reset appropriate filters
        if ($('#customers-table').length > 0) {
            // Customer Journal page - reset all filter input fields
            $('#filtersForm')[0].reset();
            $('.select2').val(null).trigger('change'); 
            if (typeof customersTable !== 'undefined') {
                // Clear custom search functions
                $.fn.dataTable.ext.search = [];
                customersTable.search('').columns().search('').draw();
            }
        } else if ($('#myTable').length > 0) {
            // Account Transfers page - reset all filter input fields
            $('#filter-id').val('');
            $('#filter-from-account').val('');
            $('#filter-to-account').val('');
            $('#filter-amount').val('');
            $('#filter-currency').val('');
            $('#filter-statement').val('');
            $('#filter-date-from').val('');
            $('#filter-date-to').val('');
            $('#filter-employee').val('');
            if (typeof deductionTable !== 'undefined') {
                // Clear custom search functions
                $.fn.dataTable.ext.search = [];
                deductionTable.search('').columns().search('').draw();
            }
        } else if ($('#categoriesTable').length > 0) {
            // Pricing Groups page - reset all filter input fields
            $('#filter-id').val('');
            $('#filter-group-name').val('');
            $('#filter-mobile').val('');
            $('#filter-you').val('');
            $('#filter-you-packages').val('');
            $('#filter-safafon').val('');
            $('#filter-wifi').val('');
            $('#filter-mobile-wholesale').val('');
            $('#filter-you-wholesale').val('');
            $('#filter-safafon-wholesale').val('');
            $('#filter-internet').val('');
            $('#filter-landline').val('');
            $('#filter-mobile-recharge').val('');
            $('#filter-money-transfer').val('');
            if (typeof pricingGroupsTable !== 'undefined') {
                // Clear custom search functions
                $.fn.dataTable.ext.search = [];
                pricingGroupsTable.search('').columns().search('').draw();
            }
        }
        
        alert('تم إعادة تعيين الفلاتر');
    });

    // Handle refresh button
    $('#refreshBtn').on('click', function () {
        alert('سيتم تحديث بيانات الجدول');
        // Reload the appropriate DataTable
        if ($('#customers-table').length > 0 && typeof customersTable !== 'undefined') {
            customersTable.draw();
        } else if ($('#myTable').length > 0 && typeof deductionTable !== 'undefined') {
            deductionTable.draw();
        } else if ($('#categoriesTable').length > 0 && typeof pricingGroupsTable !== 'undefined') {
            pricingGroupsTable.draw();
        }
    });
    
    // Handle auto refresh button
    $('#autoRefresh').on('click', function () {
        alert('سيتم تجديد الجدول تلقائياً 🔄');
        // In a real application, you would implement auto-refresh functionality here
    });
    
    // Handle follow up button
    $('#followUp').on('click', function () {
        alert('فتح نافذة المتابعة 👀');
        // In a real application, you would open a follow-up modal or page here
    });
    
    // Handle export all button
    $('#exportAll').on('click', function () {
        alert('تصدير البيانات 📤');
        // In a real application, you would implement export functionality here
    });
    
    // Handle select all columns button
    $('#selectAllColumns').on('click', function () {
        alert('تحديد جميع الأعمدة');
        // In a real application, you would implement column selection functionality here
    });
});