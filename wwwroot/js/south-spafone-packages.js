$(function () {
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
        $('#filter-package-name').val('');
        $('#filter-package-price').val('');
        $('#filter-year').selectpicker('val', '');
        $('#filter-records').selectpicker('val', '');
        $('.selectpicker').selectpicker('refresh');
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
});