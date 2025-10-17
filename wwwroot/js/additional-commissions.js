$(function () {
    // Variable to track the currently selected row
    let selectedRow = null;
    
    // Initialize DataTable
    const dt = $("#categoriesTable").DataTable({
        paging: true,
        lengthChange: false,
        searching: false,
        ordering: true,
        info: true,
        autoWidth: false,
        responsive: true,
        // Add buttons extension
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'print',
                text: 'طباعه',
                className: 'btn btn-outline-secondary btn-sm',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'colvis',
                text: 'تحديد الحقول',
                className: 'btn btn-outline-secondary btn-sm',
                collectionLayout: 'fixed two-column'
            },
            {
                extend: 'excelHtml5',
                text: 'تصدير اكسل',
                className: 'btn btn-outline-secondary btn-sm',
                exportOptions: {
                    columns: ':visible'
                }
            }
        ],
        language: {
            emptyTable: "لا توجد بيانات",
            info: "إظهار _START_ إلى _END_ من _TOTAL_ سجل",
            infoEmpty: "إظهار 0 إلى 0 من 0",
            paginate: { first:"الأولى", last:"الأخيرة", next:"التالي", previous:"السابق" },
            buttons: {
                colvis: 'تحديد الحقول',
                print: 'طباعه',
                excel: 'تصدير اكسل'
            }
        }
    });
    
    // Move buttons to filter section
    dt.buttons().container().appendTo('#datatables-buttons-container');
    
    // Hide the default buttons container since we're using custom buttons
    $('.dt-buttons').hide();
    
    // Reinitialize buttons when filter section is shown
    $('#toggleFilters').on('click', function() {
        setTimeout(function() {
            // Refresh button styles when filter section is toggled
            $('.dt-buttons .btn').addClass('btn-sm');
        }, 100);
    });
    
    // Ensure buttons are properly styled after initialization
    setTimeout(function() {
        $('.dt-buttons .btn').addClass('btn-sm');
    }, 500);
    
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
        $('#filter-id').val('');
        $('#filter-from-amount').val('');
        $('#filter-to-amount').val('');
        $('#filter-percentage').val('');
        $('#filter-group').selectpicker('val', '');
        $('.selectpicker').selectpicker('refresh');
        alert('تم إعادة تعيين الفلاتر');
    });
    
    // Handle row selection
    $('#categoriesTable tbody').on('click', 'tr', function(e) {
        // Prevent row selection when clicking on action buttons or dropdowns
        if ($(e.target).closest('.dropdown-toggle, .dropdown-menu, .btn').length) {
            return;
        }
        
        // Toggle selection
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            selectedRow = null;
        } else {
            // Remove selection from other rows
            $('#categoriesTable tbody tr.selected').removeClass('selected');
            $(this).addClass('selected');
            selectedRow = $(this);
        }
        
        // Enable/disable top action buttons based on selection
        if (selectedRow) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else {
            $('#topEditButton, #topViewButton').addClass('disabled');
        }
    });
    
    // Handle select all checkbox
    $('#selectAll').on('change', function() {
        const isChecked = $(this).is(':checked');
        $('.category-checkbox').prop('checked', isChecked);
        
        // If all rows are selected, enable top action buttons
        if (isChecked) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else {
            $('#topEditButton, #topViewButton').addClass('disabled');
            selectedRow = null;
        }
    });
    
    // Handle individual checkbox selection
    $('#categoriesTable tbody').on('change', '.category-checkbox', function() {
        // If any checkbox is checked, enable top action buttons
        if ($('.category-checkbox:checked').length > 0) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else {
            $('#topEditButton, #topViewButton').addClass('disabled');
            selectedRow = null;
        }
    });
    
    // Handle top action buttons
    $('#topEditButton').on('click', function(e) {
        e.preventDefault();
        if (selectedRow) {
            editCommission(selectedRow);
        } else {
            alert('الرجاء تحديد صف أولاً');
        }
    });
    
    $('#topViewButton').on('click', function(e) {
        e.preventDefault();
        if (selectedRow) {
            viewCommission(selectedRow);
        } else {
            alert('الرجاء تحديد صف أولاً');
        }
    });
    
    // Handle action buttons in the table
    $('#categoriesTable').on('click', '[data-action]', function (e) {
        e.preventDefault(); // Prevent default action
        const action = $(this).data('action');
        const row = $(this).closest('tr');
        
        switch (action) {
            case 'view':
                viewCommission(row);
                break;
            case 'edit':
                editCommission(row);
                break;
        }
    });
    
    // Function to view commission
    function viewCommission(row) {
        // In a real application, you would fetch the data from the server
        // For now, we'll just show the modal
        console.log('Showing view modal');
        var modal = new bootstrap.Modal(document.getElementById('viewCommissionModal'));
        modal.show();
    }
    
    // Function to edit commission
    function editCommission(row) {
        // In a real application, you would populate the form with data from the server
        // For now, we'll just show the modal
        console.log('Showing edit modal');
        var modal = new bootstrap.Modal(document.getElementById('editCommissionModal'));
        modal.show();
    }
    
    // Handle form submissions with AJAX
    $('#addCommissionForm, #editCommissionForm').on('submit', function (e) {
        e.preventDefault();
        
        const form = $(this);
        const formId = form.attr('id');
        const prefix = formId === 'addCommissionForm' ? 'add' : 'edit';
        
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
    $('#addCommissionModal .modal-footer .btn-primary, #editCommissionModal .modal-footer .btn-primary').on('click', function () {
        const modal = $(this).closest('.modal');
        const form = modal.find('form');
        const formId = form.attr('id');
        const prefix = formId === 'addCommissionForm' ? 'add' : 'edit';
        
        // Get form data
        const formData = getFormData(prefix);
        
        // Validate form
        if (!validateForm(formData, prefix)) {
            return;
        }
        
        // Submit form via AJAX
        submitFormViaAjax(formData, prefix);
    });
    
    // Function to get form data
    function getFormData(prefix) {
        const data = {
            fromAmount: $(`#${prefix}-from-amount`).val(),
            toAmount: $(`#${prefix}-to-amount`).val(),
            group: $(`#${prefix}-group`).val(),
            percentage: $(`#${prefix}-percentage`).val(),
            networkInternet: $(`#${prefix}-network-internet`).is(':checked'),
            networkPhone: $(`#${prefix}-network-phone`).is(':checked'),
            networkForge: $(`#${prefix}-network-forge`).is(':checked')
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
        if (!data.fromAmount) {
            $(`#${prefix}-from-amount`).addClass('is-invalid');
            $(`#${prefix}-from-amount`).after('<div class="invalid-feedback">الرجاء إدخال مبلغ البداية</div>');
            isValid = false;
        }
        
        if (!data.toAmount) {
            $(`#${prefix}-to-amount`).addClass('is-invalid');
            $(`#${prefix}-to-amount`).after('<div class="invalid-feedback">الرجاء إدخال مبلغ النهاية</div>');
            isValid = false;
        }
        
        if (!data.group) {
            $(`#${prefix}-group`).addClass('is-invalid');
            $(`#${prefix}-group`).after('<div class="invalid-feedback">الرجاء اختيار المجموعة</div>');
            isValid = false;
        }
        
        if (!data.percentage) {
            $(`#${prefix}-percentage`).addClass('is-invalid');
            $(`#${prefix}-percentage`).after('<div class="invalid-feedback">الرجاء إدخال النسبة</div>');
            isValid = false;
        }
        
        // At least one network must be selected
        if (!data.networkInternet && !data.networkPhone && !data.networkForge) {
            $(`#${prefix}-network-internet`).after('<div class="invalid-feedback d-block">الرجاء اختيار شبكة واحدة على الأقل</div>');
            isValid = false;
        }
        
        return isValid;
    }
    
    // Function to submit form via AJAX
    function submitFormViaAjax(data, prefix) {
        // Show loading indicator
        const submitBtn = $(`#${prefix}CommissionModal .modal-footer .btn-primary`);
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
            var modal = bootstrap.Modal.getInstance(document.getElementById(`${prefix}CommissionModal`));
            if (modal) {
                modal.hide();
            } else {
                new bootstrap.Modal(document.getElementById(`${prefix}CommissionModal`)).hide();
            }
            
            // Show success message
            alert('تم حفظ البيانات بنجاح');
            
            // Reload the DataTable
            dt.ajax.reload();
        }, 1500);
    }
    
    // Handle edit from view modal
    $('#editFromViewBtn').on('click', function() {
        var viewModal = bootstrap.Modal.getInstance(document.getElementById('viewCommissionModal'));
        if (viewModal) {
            viewModal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('viewCommissionModal')).hide();
        }
        var editModal = new bootstrap.Modal(document.getElementById('editCommissionModal'));
        editModal.show();
    });
});