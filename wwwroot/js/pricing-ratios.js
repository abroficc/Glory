$(document).ready(function () {
    // Handle filter toggle button - Use event delegation to ensure our handler runs
    $(document).off('click', '#toggleFilters').on('click', '#toggleFilters', function(e) {
        e.preventDefault();
        e.stopImmediatePropagation(); // Prevent other handlers from running
        console.log('Pricing Ratios Filter toggle button clicked');
        
        var filterSection = $('#filterSection');
        var icon = $(this).find('i');
        var textSpan = $('#toggleFiltersText');
        
        console.log('Filter section is visible:', filterSection.is(':visible'));
        
        if (filterSection.is(':visible')) {
            // Hide the filter section
            filterSection.hide();
            icon.removeClass('ti-filter-off').addClass('ti-filter');
            textSpan.text('إظهار الفلترة');
            console.log('Hiding filter section');
        } else {
            // Show the filter section
            filterSection.show();
            icon.removeClass('ti-filter').addClass('ti-filter-off');
            textSpan.text('إخفاء الفلترة');
            console.log('Showing filter section');
        }
    });
    
    // Log when document is ready
    console.log('Pricing Ratios document ready');
    
    // Initialize DataTable with client-side processing (static data)
    var pricingRatiosTable = $('#categoriesTable').DataTable({
        "processing": true,
        "serverSide": false, // Changed to client-side processing
        "data": [ // Static data
            [1, 1, "تسديد رصيد موبايل", "يمن موبايل", ""],
            [2, 2, "رصيد وباقة", "شحن فوري يمن موبايل", ""],
            [3, 1, "تسديد الانترنت ADSL", "يو", ""],
            [4, 3, "تسديد الهاتف الثابت", "باقات يو", ""]
        ],
        "columns": [
            { 
                "data": null, 
                "orderable": false, 
                "render": function (data, type, row) {
                    return '<input type="checkbox" class="row-checkbox" data-id="' + row[0] + '">';
                }
            },
            { "data": 0 }, // الرقم (Number)
            { "data": 1 }, // المجموعة (Group)
            { "data": 2 }, // الخدمة (Service)
            { "data": 3 }, // الشبكة (Network)
            { 
                "data": null, 
                "orderable": false, 
                "render": function (data, type, row) {
                    return '<div class="dropdown">' +
                        '<button class="btn btn-sm btn-outline-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">' +
                        'للمزيد' +
                        '</button>' +
                        '<ul class="dropdown-menu dropdown-menu-end">' +
                        '<li><a class="dropdown-item" href="#" data-action="edit"><i class="ti ti-pencil me-1"></i> تعديل</a></li>' +
                        '<li><a class="dropdown-item" href="#" data-action="view"><i class="ti ti-eye me-1"></i> مشاهدة</a></li>' +
                        '<li><a class="dropdown-item" href="#"><i class="ti ti-trash me-1"></i> حذف</a></li>' +
                        '</ul>' +
                        '</div>';
                }
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.13.8/i18n/ar.json"
        },
        "order": [[1, "asc"]],
        "pageLength": 10,
        "responsive": true,
        "dom": '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>' +
               '<"row"<"col-sm-12"tr>>' +
               '<"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>'
    });
    
    // Initialize bootstrap-select for dropdowns
    function initializeSelectPicker() {
        $('.selectpicker').selectpicker({
            style: 'btn-light',
            liveSearch: true,
            liveSearchPlaceholder: 'ابحث...',
            noneSelectedText: 'لم يتم تحديد أي شيء',
            noneResultsText: 'لا توجد نتائج لـ {0}',
            selectAllText: 'تحديد الكل',
            deselectAllText: 'إلغاء تحديد الكل',
            dropupAuto: false,
            width: '100%',
            container: 'body'
        });
    }
    
    // Initialize selectpickers when document is ready
    initializeSelectPicker();
    
    // Re-initialize bootstrap-select when modals are shown
    $('.modal').on('shown.bs.modal', function () {
        $('.selectpicker').selectpicker('refresh');
    });
    
    // Initialize top action buttons as disabled
    $('#topEditButton, #topViewButton').addClass('disabled');
    
    // Handle form submissions with AJAX
    $('#addCategoryForm, #editCategoryForm').on('submit', function (e) {
        e.preventDefault();
        
        const form = $(this);
        const formId = form.attr('id');
        const prefix = formId === 'addCategoryForm' ? 'add' : 'edit';
        
        // Get form data
        const formData = getFormData(prefix);
        
        // Validate form
        if (!validateForm(formData, prefix)) {
            return;
        }
        
        // Submit form via AJAX
        submitFormViaAjax(formData, prefix);
    });
    
    // Handle save button click in modal footer
    $('#addCategoryModal .modal-footer .btn-primary, #editCategoryModal .modal-footer .btn-primary').on('click', function () {
        const modal = $(this).closest('.modal');
        const form = modal.find('form');
        const formId = form.attr('id');
        const prefix = formId === 'addCategoryForm' ? 'add' : 'edit';
        
        // Get form data
        const formData = getFormData(prefix);
        
        // Validate form
        if (!validateForm(formData, prefix)) {
            return;
        }
        
        // Submit form via AJAX
        submitFormViaAjax(formData, prefix);
    });
    
    // Handle global percentage application
    $(document).on('click', '[id$="GlobalPercentage"]', function () {
        const buttonId = $(this).attr('id');
        const prefix = buttonId.replace('GlobalPercentage', '').toLowerCase();
        
        const globalPercentage = $(`#${prefix}-global-percentage`).val();
        
        if (!globalPercentage || globalPercentage < 0 || globalPercentage > 2) {
            alert('الرجاء إدخال نسبة صحيحة بين 0 و 2');
            return;
        }
        
        // Apply the percentage to all fields
        applyGlobalPercentage(globalPercentage, prefix);
    });
    
    // Handle edit from view button
    $('#editFromViewBtn').on('click', function () {
        // Close view modal
        $('#viewCategoryModal').modal('hide');
        
        // Open edit modal (in a real app, you would populate it with data first)
        $('#editCategoryModal').modal('show');
    });
    
    // Handle action buttons in the table
    $('#categoriesTable').on('click', '[data-action]', function (e) {
        e.preventDefault(); // Prevent default action
        const action = $(this).data('action');
        const row = $(this).closest('tr');
        
        switch (action) {
            case 'view':
                viewCategory(row);
                break;
            case 'edit':
                editCategory(row);
                break;
        }
    });
    
    // Function to get form data
    function getFormData(prefix) {
        const data = {
            minAmount: $(`#${prefix}-min-amount`).val(),
            maxAmount: $(`#${prefix}-max-amount`).val(),
            service: $(`#${prefix}-service`).val(),
            currency: $(`#${prefix}-currency`).val(),
            network: $(`#${prefix}-network`).val(),
            pricingGroup: $(`#${prefix}-pricing-group`).val(),
            sendNotification: $(`#${prefix}-send-notification`).is(':checked')
        };
        
        // Get range data
        for (let i = 1; i <= 5; i++) {
            data[`range${i}Min`] = $(`#${prefix}-range${i}-min`).val();
            data[`range${i}Max`] = $(`#${prefix}-range${i}-max`).val();
            data[`range${i}Ratio`] = $(`#${prefix}-range${i}-ratio`).val();
        }
        
        return data;
    }
    
    // Function to validate form
    function validateForm(data, prefix) {
        let isValid = true;
        
        // Clear previous validation states
        $('.is-invalid').removeClass('is-invalid');
        $('.invalid-feedback').remove();
        
        // Validate required fields
        if (!data.minAmount) {
            $(`#${prefix}-min-amount`).addClass('is-invalid');
            $(`#${prefix}-min-amount`).after('<div class="invalid-feedback">الرجاء إدخال الحد الأدنى</div>');
            isValid = false;
        }
        
        if (!data.maxAmount) {
            $(`#${prefix}-max-amount`).addClass('is-invalid');
            $(`#${prefix}-max-amount`).after('<div class="invalid-feedback">الرجاء إدخال الحد الأقصى</div>');
            isValid = false;
        }
        
        // Validate service selection
        if (!data.service) {
            $(`#${prefix}-service`).addClass('is-invalid');
            $(`#${prefix}-service`).after('<div class="invalid-feedback">الرجاء اختيار الخدمة</div>');
            isValid = false;
        }
        
        // Validate network selection
        if (!data.network) {
            $(`#${prefix}-network`).addClass('is-invalid');
            $(`#${prefix}-network`).after('<div class="invalid-feedback">الرجاء اختيار الشبكة</div>');
            isValid = false;
        }
        
        // Validate numeric fields (between 0 and 2 for ratios)
        for (let i = 1; i <= 5; i++) {
            const ratio = data[`range${i}Ratio`];
            if (ratio && (ratio < 0 || ratio > 2)) {
                $(`#${prefix}-range${i}-ratio`).addClass('is-invalid');
                $(`#${prefix}-range${i}-ratio`).after('<div class="invalid-feedback">الرجاء إدخال نسبة بين 0 و 2</div>');
                isValid = false;
            }
        }
        
        return isValid;
    }
    
    // Function to submit form via AJAX
    function submitFormViaAjax(data, prefix) {
        // Show loading indicator
        const submitBtn = $(`#${prefix}CategoryModal .modal-footer .btn-primary`);
        const originalText = submitBtn.html();
        submitBtn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> جاري الحفظ...');
        submitBtn.prop('disabled', true);
        
        // In a real application, you would send the data to the server
        // For now, we'll simulate an AJAX call
        setTimeout(function () {
            // Reset button
            submitBtn.html(originalText);
            submitBtn.prop('disabled', false);
            
            // Close modal
            $(`#${prefix}CategoryModal`).modal('hide');
            
            // Show success message
            alert('تم حفظ البيانات بنجاح');
            
            // Reload the DataTable
            pricingRatiosTable.ajax.reload();
        }, 1500);
    }
    
    // Function to apply global percentage
    function applyGlobalPercentage(percentage, prefix) {
        for (let i = 1; i <= 5; i++) {
            if ($(`#${prefix}-range${i}-ratio`).val() !== '') {
                $(`#${prefix}-range${i}-ratio`).val(percentage);
            }
        }
        
        alert(`تم تطبيق النسبة ${percentage} على جميع الحقول`);
    }
    
    // Function to view category
    function viewCategory(row) {
        // In a real application, you would fetch the data from the server
        // For now, we'll just show the modal
        console.log('Showing view modal');
        $('#viewCategoryModal').modal('show');
    }
    
    // Function to edit category
    function editCategory(row) {
        // In a real application, you would populate the form with data from the server
        // For now, we'll just show the modal
        console.log('Showing edit modal');
        $('#editCategoryModal').modal('show');
    }
    
    // Initialize tooltips
    $('[data-bs-toggle="tooltip"]').tooltip();
    
    // Handle select all columns button
    $('#selectAllColumns').on('click', function () {
        const allChecked = $('#selectAllCheckbox').prop('checked');
        $('.row-checkbox').prop('checked', !allChecked);
        $('#selectAllCheckbox').prop('checked', !allChecked);
        // Enable/disable top action buttons based on selection
        toggleTopActionButtons();
    });
    
    // Handle individual row checkbox changes
    $('#categoriesTable tbody').on('change', '.row-checkbox', function () {
        // Enable/disable top action buttons based on selection
        toggleTopActionButtons();
    });
    
    // Function to enable/disable top action buttons based on row selection
    function toggleTopActionButtons() {
        const selectedRows = $('.row-checkbox:checked').length;
        if (selectedRows === 1) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else if (selectedRows === 0) {
            $('#topEditButton, #topViewButton').addClass('disabled');
        } else {
            // Multiple rows selected - only allow view in this example
            $('#topEditButton').addClass('disabled');
            $('#topViewButton').removeClass('disabled');
        }
    }
    
    // Handle top edit button click
    $('#topEditButton').on('click', function (e) {
        e.preventDefault();
        const selectedRows = $('.row-checkbox:checked');
        if (selectedRows.length === 1) {
            // Get the row data
            const row = selectedRows.closest('tr');
            editCategory(row);
        } else {
            alert('الرجاء تحديد صف واحد للتعديل');
        }
    });
    
    // Handle top view button click
    $('#topViewButton').on('click', function (e) {
        e.preventDefault();
        const selectedRows = $('.row-checkbox:checked');
        if (selectedRows.length >= 1) {
            // Get the first selected row data
            const row = selectedRows.first().closest('tr');
            viewCategory(row);
        } else {
            alert('الرجاء تحديد صف واحد على الأقل للمشاهدة');
        }
    });
    
    // Handle print button
    $('#printButton').on('click', function () {
        window.print();
    });
    
    // Handle export to Excel button
    $('#exportExcelButton').on('click', function () {
        alert('تصدير إلى Excel');
        // In a real application, you would implement Excel export functionality here
    });
    
    // Handle filter application
    $('#applyFilters').on('click', function () {
        // Get filter values
        var filterPricingGroup = $('#filter-pricing-group').val();
        var filterAllServices = $('#filter-all-services').val();
        var filterRecords = $('#rowsCount').val();

        // Apply filters to DataTable
        // Note: Column index 1 is now the pricing group column (was ID column)
        pricingRatiosTable.column(1).search(filterPricingGroup && filterPricingGroup !== "مجموعة التسعيرة" ? filterPricingGroup : '').draw();
        // Column index 2 is now the service column (was min amount column)
        pricingRatiosTable.column(2).search(filterAllServices && filterAllServices !== "كل الخدمات" ? filterAllServices : '').draw();
        
        // Set page length based on records filter
        if (filterRecords) {
            pricingRatiosTable.page.len(filterRecords).draw();
        }
    });
    
    // Handle reset filters button
    $('#resetFilters').on('click', function () {
        // Reset all filter input fields
        $('#filter-pricing-group').selectpicker('val', '');
        $('#filter-all-services').selectpicker('val', '');
        $('#rowsCount').selectpicker('val', '30');
        
        // Refresh the selectpickers to show the placeholders
        $('#filter-pricing-group').selectpicker('refresh');
        $('#filter-all-services').selectpicker('refresh');
        $('#rowsCount').selectpicker('refresh');
        
        // Reset DataTable page length to default (30 as requested)
        pricingRatiosTable.page.len(30).draw();
        
        // Clear DataTable filters
        pricingRatiosTable.search('').columns().search('').draw();
        
        alert('تم إعادة تعيين الفلاتر');
    });
});