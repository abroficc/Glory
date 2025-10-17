$(document).ready(function () {
    // Handle filter toggle button - Use event delegation to ensure our handler runs
    $(document).off('click', '#toggleFilters').on('click', '#toggleFilters', function(e) {
        e.preventDefault();
        e.stopImmediatePropagation(); // Prevent other handlers from running
        console.log('South Spafone Filter toggle button clicked');
        
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
    // Initialize DataTable with client-side processing (static data)
    var dt = $('#categoriesTable').DataTable({
        "processing": true,
        "serverSide": false, // Changed to client-side processing
        "data": [ // Static data
            [1, "الباقة الذهبية", "100"],
            [2, "الباقة الفضية", "50"],
            [3, "الباقة البرونزية", "25"]
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
            { "data": 1 }, // الفئة (Category)
            { "data": 2 }, // السعر (Price)
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
        "pageLength": 30,
        "responsive": true,
        "dom": '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>' +
               '<"row"<"col-sm-12"tr>>' +
               '<"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>'
    });
    
    // Handle filter application
    $('#applyFilters').on('click', function () {
        // Get filter values
        var filterPackageName = $('#filter-package-name').val();
        var filterPrice = $('#filter-price').val();
        var filterRecords = $('#rowsCount').val();

        // Apply filters to DataTable
        // Column index 2 is the package name column (accounting for checkbox column)
        dt.column(2).search(filterPackageName ? filterPackageName : '').draw();
        // Column index 3 is the price column (accounting for checkbox column)
        dt.column(3).search(filterPrice ? filterPrice : '').draw();
        
        // Set page length based on records filter
        if (filterRecords) {
            dt.page.len(filterRecords).draw();
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
    
    // Handle filter toggle button
    $('#toggleFilters').on('click', function() {
        var filterSection = $('#filterSection');
        var icon = $(this).find('i');
        var textSpan = $('#toggleFiltersText');
        
        if (filterSection.is(':visible')) {
            // Hide the filter section
            filterSection.hide();
            icon.removeClass('ti-filter-off').addClass('ti-filter');
            textSpan.text('إظهار الفلترة');
        } else {
            // Show the filter section
            filterSection.show();
            icon.removeClass('ti-filter').addClass('ti-filter-off');
            textSpan.text('إخفاء الفلترة');
        }
    });
    
    // Initialize bootstrap-select for category selection with enhanced options
    function initializeSelectPicker() {
        $('.selectpicker').selectpicker({
            style: 'btn-light',
            liveSearch: true,
            liveSearchPlaceholder: 'ابحث...',
            noneSelectedText: 'لم يتم تحديد أي شيء',
            noneResultsText: 'لا توجد نتائج لـ {0}',
            selectAllText: 'تحديد الكل',
            deselectAllText: 'إلغاء تحديد الكل',
            dropupAuto: false,   // منع السلوك التلقائي
            width: '100%',
            container: 'body'    // إخراج القائمة خارج أي كارد/مودال
        });
    }
    
    // Initialize selectpickers when document is ready
    initializeSelectPicker();
    
    // Re-initialize bootstrap-select when modals are shown or hidden
    $('.modal').on('shown.bs.modal hidden.bs.modal', function () {
        $('.selectpicker').selectpicker('refresh');
    });

    // Handle reset filters button
    $('#resetFilters').on('click', function() {
        // Reset all filter input fields
        $('#filter-package-name').val('');
        $('#filter-price').val('');
        $('#rowsCount').selectpicker('val', '30');
        
        // Refresh the selectpickers to show the placeholders
        $('#rowsCount').selectpicker('refresh');
        
        // Reset DataTable page length to default (30 as requested)
        dt.page.len(30).draw();
        
        // Clear DataTable filters
        dt.search('').columns().search('').draw();
        
        alert('تم إعادة تعيين الفلاتر');
    });
    
    // Handle set price button functionality
    $(document).on('click', '[id$="-set-price-btn"]', function() {
        var prefix = $(this).attr('id').replace('-set-price-btn', '');
        var priceValue = $('#' + prefix + '-set-price-input').val();
        
        if (priceValue && !isNaN(priceValue)) {
            // Set the unit price for all packages
            $('#' + prefix + '-unit-price').val(priceValue);
            
            // Show success message
            alert('تم ضبط السعر لجميع الباقات والشحن الفوري');
        } else {
            alert('الرجاء إدخال سعر صحيح');
        }
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
    
    // Function to get form data
    function getFormData(prefix) {
        const data = {
            packageName: $(`#${prefix}-package-name`).val(),
            price: $(`#${prefix}-price`).val(),
            bindingAmount6: $(`#${prefix}-binding-amount6`).val(),
            convertToRobot: $(`#${prefix}-convert-to-robot`).val(),
            quantity: $(`#${prefix}-quantity`).val(),
            unitPrice: $(`#${prefix}-unit-price`).val()
        };
        
        return data;
    }
    
    // Function to validate form
    function validateForm(data, prefix) {
        let isValid = true;
        
        // Clear previous validation states
        $('.is-invalid').removeClass('is-invalid');
        $('.invalid-feedback').remove();
        
        // Validate required fields
        if (!data.packageName) {
            $(`#${prefix}-package-name`).addClass('is-invalid');
            $(`#${prefix}-package-name`).after('<div class="invalid-feedback">الرجاء إدخال الفئة</div>');
            isValid = false;
        }
        
        if (!data.price) {
            $(`#${prefix}-price`).addClass('is-invalid');
            $(`#${prefix}-price`).after('<div class="invalid-feedback">الرجاء إدخال السعر</div>');
            isValid = false;
        }
        
        if (!data.bindingAmount6) {
            $(`#${prefix}-binding-amount6`).addClass('is-invalid');
            $(`#${prefix}-binding-amount6`).after('<div class="invalid-feedback">الرجاء إدخال مبلغ الربط6</div>');
            isValid = false;
        }
        
        if (!data.quantity) {
            $(`#${prefix}-quantity`).addClass('is-invalid');
            $(`#${prefix}-quantity`).after('<div class="invalid-feedback">الرجاء إدخال الكمية</div>');
            isValid = false;
        }
        
        if (!data.unitPrice) {
            $(`#${prefix}-unit-price`).addClass('is-invalid');
            $(`#${prefix}-unit-price`).after('<div class="invalid-feedback">الرجاء إدخال سعر الوحدة</div>');
            isValid = false;
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
            dt.ajax.reload();
        }, 1500);
    }
    
    // Initialize tooltips
    $('[data-bs-toggle="tooltip"]').tooltip();
});