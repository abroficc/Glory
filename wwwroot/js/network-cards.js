$(document).ready(function () {
    // Handle filter toggle button - Use event delegation to ensure our handler runs
    $(document).off('click', '#toggleFilters').on('click', '#toggleFilters', function(e) {
        e.preventDefault();
        e.stopImmediatePropagation(); // Prevent other handlers from running
        console.log('Network Cards Filter toggle button clicked');
        
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
    console.log('Network Cards document ready');
    
    // Initialize DataTable with client-side processing (static data)
    var networkCardsTable = $('#categoriesTable').DataTable({
        "processing": true,
        "serverSide": false, // Changed to client-side processing
        "data": [ // Static data
            [1, "1234567890", "77", "فئة 1 - 100 ريال", "2023-10-01", "إبتاع"],
            [2, "1234567891", "73", "فئة 2 - 200 ريال", "2023-10-02", "غير مباع"],
            [3, "1234567892", "71", "فئة 3 - 300 ريال", "2023-10-03", "إبتاع"]
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
            { "data": 1 }, // رقم الكرت (Card Number)
            { "data": 2 }, // رقم الشبكة (Network Number)
            { "data": 3 }, // الفئة والسعر (Category and Price)
            { "data": 4 }, // تاريخ الاضافة (Date Added)
            { "data": 5 }, // الحالة (Status)
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
    setTimeout(function() {
        initializeSelectPicker();
    }, 100);
    
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
        var viewModal = bootstrap.Modal.getInstance(document.getElementById('viewCategoryModal'));
        if (viewModal) {
            viewModal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('viewCategoryModal')).hide();
        }
        
        // Open edit modal (in a real app, you would populate it with data first)
        var editModal = new bootstrap.Modal(document.getElementById('editCategoryModal'));
        editModal.show();
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
            networkExample: $(`#${prefix}-network-example`).val(),
            cardNumber: $(`#${prefix}-card-number`).val(),
            category: $(`#${prefix}-category`).val()
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
        if (!data.cardNumber) {
            $(`#${prefix}-card-number`).addClass('is-invalid');
            $(`#${prefix}-card-number`).after('<div class="invalid-feedback">الرجاء إدخال رقم الكرت</div>');
            isValid = false;
        }
        
        if (!data.category) {
            $(`#${prefix}-category`).addClass('is-invalid');
            $(`#${prefix}-category`).after('<div class="invalid-feedback">الرجاء إدخال الفئة</div>');
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
            var modal = bootstrap.Modal.getInstance(document.getElementById(`${prefix}CategoryModal`));
            if (modal) {
                modal.hide();
            } else {
                new bootstrap.Modal(document.getElementById(`${prefix}CategoryModal`)).hide();
            }
            
            // Show success message
            alert('تم حفظ البيانات بنجاح');
            
            // Reload the DataTable
            networkCardsTable.ajax.reload();
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
        var modal = new bootstrap.Modal(document.getElementById('viewCategoryModal'));
        modal.show();
    }
    
    // Function to edit category
    function editCategory(row) {
        // In a real application, you would populate the form with data from the server
        // For now, we'll just show the modal
        console.log('Showing edit modal');
        var modal = new bootstrap.Modal(document.getElementById('editCategoryModal'));
        modal.show();
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
        var filterCardNumber = $('#filter-card-number').val();
        var filterStatus = $('#status').val();
        var filterRecords = $('#rowsCount').val();

        // Apply filters to DataTable
        // Column index 2 is the card number column (accounting for checkbox column)
        networkCardsTable.column(2).search(filterCardNumber ? filterCardNumber : '').draw();
        // Column index 6 is the status column (accounting for checkbox column)
        networkCardsTable.column(6).search(filterStatus && filterStatus !== "الحالة" ? filterStatus : '').draw();
        
        // Set page length based on records filter
        if (filterRecords) {
            networkCardsTable.page.len(filterRecords).draw();
        }
    });
    
    // Handle reset filters button
    $('#resetFilters').on('click', function () {
        // Reset all filter input fields
        $('#filter-card-number').val('');
        $('#status').selectpicker('val', '');
        $('#rowsCount').selectpicker('val', '30');
        
        // Refresh the selectpickers to show the placeholders
        $('#status').selectpicker('refresh');
        $('#rowsCount').selectpicker('refresh');
        
        // Reset DataTable page length to default (30 as requested)
        networkCardsTable.page.len(30).draw();
        
        // Clear DataTable filters
        networkCardsTable.search('').columns().search('').draw();
        
        alert('تم إعادة تعيين الفلاتر');
    });
});