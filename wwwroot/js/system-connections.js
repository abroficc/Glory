// System Connections Page JavaScript

// Initialize the page when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    // Bind event handlers
    bindEventHandlers();
    
    // Initialize toast notifications
    initializeToasts();
});

// Initialize toast notifications
function initializeToasts() {
    // Toast container already exists in HTML
}

// Show toast notification
function showToast(message, type = 'info') {
    const toastContainer = document.querySelector('.toast-container') || createToastContainer();
    
    const toast = document.createElement('div');
    toast.className = `toast ${type} show`;
    
    let icon = 'ℹ️';
    if (type === 'success') icon = '✅';
    else if (type === 'error') icon = '❌';
    else if (type === 'warning') icon = '⚠️';
    
    toast.innerHTML = `
        <div class="toast-icon">${icon}</div>
        <div class="toast-message">${message}</div>
        <button class="toast-close">&times;</button>
    `;
    
    toastContainer.appendChild(toast);
    
    // Add close functionality
    const closeBtn = toast.querySelector('.toast-close');
    closeBtn.addEventListener('click', function() {
        toast.remove();
    });
    
    // Auto hide after 5 seconds
    setTimeout(() => {
        if (toast.parentNode) {
            toast.remove();
        }
    }, 5000);
}

// Create toast container if it doesn't exist
function createToastContainer() {
    const container = document.createElement('div');
    container.className = 'toast-container';
    document.body.appendChild(container);
    return container;
}

// Show loader
function showLoader() {
    let loader = document.getElementById('loader');
    if (!loader) {
        loader = document.createElement('div');
        loader.id = 'loader';
        loader.className = 'loader-overlay';
        loader.innerHTML = `
            <div>
                <div class="loader-spinner"></div>
                <div class="loader-text">جارٍ البحث...</div>
            </div>
        `;
        document.body.appendChild(loader);
    }
    loader.style.display = 'flex';
}

// Hide loader
function hideLoader() {
    const loader = document.getElementById('loader');
    if (loader) {
        loader.style.display = 'none';
    }
}

// Open unified modal
function openUnifiedModal(tabType) {
    // Show the unified modal
    const modal = new bootstrap.Modal(document.getElementById('unifiedModal'));
    modal.show();
}

// Bind all event handlers
function bindEventHandlers() {
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
    
    // Reset filters
    $('#resetFilters').click(function() {
        $('#filter-provider-name, #filter-network, #filter-employees, #filter-account-sources').val('');
        $('#filter-direction').selectpicker('val', '');
        $('.selectpicker').selectpicker('refresh');
        showToast('تم إعادة تعيين الفلاتر', 'info');
    });
    
    // Apply filters with real AJAX
    $('#searchButton').click(function() {
        const filters = {
            providerName: $('#filter-provider-name').val(),
            network: $('#filter-network').val(),
            employees: $('#filter-employees').val(),
            accountSources: $('#filter-account-sources').val(),
            direction: $('#filter-direction').val()
        };
        
        // Show loader during AJAX request
        showLoader();
        
        // In a real implementation, you would update the DataTable with new search parameters
        // For now, we'll just show a success message
        setTimeout(() => {
            hideLoader();
            showToast('تم البحث بنجاح', 'success');
        }, 1500);
    });
    
    // Refresh button
    $('#refreshBtn').click(function() {
        showLoader();
        // Reload the DataTable
        $('#providersTable').DataTable().ajax.reload();
        setTimeout(() => {
            hideLoader();
            showToast('تم تحديث الصفحة', 'success');
        }, 1000);
    });
    
    // Select all checkboxes
    $('#selectAll').click(function() {
        $('.provider-checkbox').prop('checked', this.checked);
    });
    
    // Select all button
    $('#selectAllBtn').click(function() {
        var isChecked = $('#selectAll').prop('checked');
        $('#selectAll').prop('checked', !isChecked).trigger('click');
        showToast('تم تحديد/إلغاء تحديد الكل', 'info');
    });
    
    // Delete multiple button
    $('#deleteMultipleBtn').click(function() {
        var selected = $('.provider-checkbox:checked');
        if (selected.length > 0) {
            Swal.fire({
                title: 'تأكيد الحذف',
                text: 'هل أنت متأكد من حذف ' + selected.length + ' مزود/مزودين؟',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'نعم، احذف',
                cancelButtonText: 'إلغاء'
            }).then((result) => {
                if (result.isConfirmed) {
                    showLoader();
                    // Simulate AJAX delete
                    setTimeout(() => {
                        hideLoader();
                        // Reload the DataTable after delete
                        $('#providersTable').DataTable().ajax.reload();
                        showToast('تم حذف ' + selected.length + ' مزود/مزودين', 'success');
                    }, 1500);
                }
            });
        } else {
            showToast('يرجى تحديد مزود واحد على الأقل للحذف', 'warning');
        }
    });
    
    // Add multiple button
    $('#addMultipleBtn').click(function() {
        showLoader();
        // Simulate AJAX add
        setTimeout(() => {
            hideLoader();
            // Reload the DataTable after add
            $('#providersTable').DataTable().ajax.reload();
            showToast('تم تنفيذ الإضافة المتعددة', 'success');
        }, 1500);
    });
    
    // Update multiple button
    $('#updateMultipleBtn').click(function() {
        var selected = $('.provider-checkbox:checked');
        if (selected.length > 0) {
            showLoader();
            // Simulate AJAX update
            setTimeout(() => {
                hideLoader();
                // Reload the DataTable after update
                $('#providersTable').DataTable().ajax.reload();
                showToast('تم تحديث ' + selected.length + ' مزود/مزودين', 'success');
            }, 1500);
        } else {
            showToast('يرجى تحديد مزود واحد على الأقل للتحديث', 'warning');
        }
    });
    
    // Preview multiple button
    $('#previewMultipleBtn').click(function() {
        var selected = $('.provider-checkbox:checked');
        if (selected.length > 0) {
            showLoader();
            // Simulate AJAX preview
            setTimeout(() => {
                hideLoader();
                showToast('تنفيذ معاينة ' + selected.length + ' مزود/مزودين', 'info');
            }, 1500);
        } else {
            showToast('يرجى تحديد مزود واحد على الأقل للمعاينة', 'warning');
        }
    });
    
    // Handle save button for unified modal
    $('#saveUnifiedBtn').on('click', function() {
        // Handle unified form submission
        handleUnifiedForm();
    });
    
    // Auto-sort table when queue number inputs change
    $(document).on('change', 'tbody input[type="number"]', function() {
        var $input = $(this);
        var columnIndex = $input.closest('td').index();
        
        // Check if this is the queue number column (index 1)
        if (columnIndex === 1) {
            sortTableByQueueNumber();
        }
    });
}

// Handle unified form submission
function handleUnifiedForm() {
    // Get form data
    const formData = {
        name: $('#providerName').val(),
        url: $('input[name="url"]').val(),
        ip: $('input[name="ip"]').val(),
        cid: $('input[name="cid"]').val(),
        username: $('input[name="username"]').val(),
        password: $('input[name="password"]').val(),
        token: $('input[name="token"]').val(),
        employee: $('select[name="employee"]').val(),
        accountSource: $('select[name="accountSource"]').val(),
        isrun: $('input[name="isrun"]').val(),
        type: $('input[name="type"]').val(),
        region: $('input[name="region"]:checked').val(),
        mobile: $('input[name="mobile"]').val(),
        cidsnote: $('input[name="cidsnote"]').val(),
        minamtobill: $('input[name="minamtobill"]').val(),
        maxamtobill: $('input[name="maxamtobill"]').val(),
        "pcuts": $('input[name="pcuts"]').val(),
        stopfprice: $('input[name="stopfprice"]').val(),
        systemName: $('#systemName').val(),
        connectionStatus: $('#connectionStatus').val(),
        providerType: $('#providerType').val(),
        balance: $('#balance').val(),
        direction: $('#direction').val(),
        responseTime: $('#responseTime').val(),
        supportedNetworks: $('#supportedNetworks').val(),
        accountSources: $('#accountSourcesText').val(),
        employees: $('#employeesText').val(),
        // Network section data
        ...getSelectedNetworks()
    };
    
    // Basic validation
    if (!formData.name || !formData.url || !formData.ip) {
        showToast('يرجى ملء الحقول المطلوبة', 'warning');
        return;
    }
    
    // Show loader
    showLoader();
    
    // Simulate AJAX request
    setTimeout(() => {
        hideLoader();
        $('#unifiedModal').modal('hide');
        showToast('تم حفظ الإعدادات بنجاح!', 'success');
        // Reset form
        $('#unifiedForm')[0].reset();
    }, 1500);
}

// Function to sort table by queue number
function sortTableByQueueNumber() {
    var $tbody = $('tbody');
    var $rows = $tbody.find('tr').toArray();
    
    // Sort rows based on queue number values
    $rows.sort(function(a, b) {
        var queueA = parseInt($(a).find('td:eq(1) input').val()) || 0;
        var queueB = parseInt($(b).find('td:eq(1) input').val()) || 0;
        return queueA - queueB;
    });
    
    // Re-append sorted rows to tbody
    $.each($rows, function(index, row) {
        $tbody.append(row);
    });
    
    // Update row styling after sorting
    updateRowStyling();
}

// Function to update row styling after sorting
function updateRowStyling() {
    $('tbody tr').each(function(index) {
        // Alternate row colors
        if (index % 2 === 0) {
            $(this).css('background-color', '#f9fafb');
        } else {
            $(this).css('background-color', '#ffffff');
        }
    });
}

// Generic handler for all provider actions
function handleProviderAction(id, actionType) {
    showLoader();
    
    switch(actionType) {
        case 'run':
            runWakeel(id, true);
            break;
        case 'stop':
            runWakeel(id, false);
            break;
        case 'balance':
            getBalance(id);
            break;
        case 'credit':
            addCredit(id);
            break;
        case 'pending':
            viewPending(id);
            break;
        case 'operations':
            viewOperations(id);
            break;
        case 'daily':
            viewDaily(id);
            break;
        case 'notifications':
            viewNotifications(id);
            break;
        case 'insurance':
            openInsurance(id);
            break;
        case 'account-balance':
            viewAccountBalance(id);
            break;
        case 'alerts':
            configureAlerts(id);
            break;
        case 'suspension':
            configureSuspension(id);
            break;
        case 'networks':
            showAllNetworks(id);
            break;
        case 'match':
            matchliprov(id);
            break;
        case 'notes':
            browsmynotes(id);
            break;
        case 'reports':
            browsopitems(id);
            break;
        default:
            console.warn('Action not found: ' + actionType);
            hideLoader();
            showToast('إجراء غير مدعوم', 'error');
    }
}

// تشغيل أو إيقاف مزود معين
function runWakeel(id, status) {
    // Simulate AJAX request
    setTimeout(() => {
        hideLoader();
        // Reload the DataTable after status change
        $('#providersTable').DataTable().ajax.reload();
        showToast('تغيير حالة المزود ' + id + ' إلى ' + (status ? 'مفعل' : 'غير مفعل'), 'info');
    }, 1000);
}

// استعلام عن رصيد المزود الحالي
function getBalance(id) {
    // Simulate AJAX request
    fetch(`/SystemConnection/GetBalance/${id}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            Swal.fire({
                title: 'رصيد المزود',
                text: data.balance + ' ريال',
                icon: 'info',
                confirmButtonText: 'موافق'
            });
        })
        .catch(error => {
            console.error('Error:', error);
            showToast('فشل في جلب الرصيد', 'error');
        })
        .finally(() => {
            hideLoader();
        });
}

// تفعيل أو إلغاء تفعيل شبكة معينة للمزود
function runmnet(element) {
    var providerId = $(element).data('provider-id');
    var network = $(element).data('network');
    var isChecked = $(element).is(':checked');
    
    showLoader();
    setTimeout(() => {
        hideLoader();
        // Reload the DataTable after network change
        $('#providersTable').DataTable().ajax.reload();
        showToast('تغيير حالة الشبكة ' + network + ' للمزود ' + providerId + ' إلى ' + (isChecked ? 'مفعل' : 'غير مفعل'), 'info');
    }, 1000);
}

// مطابقة العمليات المالية للمزود
function matchliprov(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('مطابقة العمليات المالية للمزود ' + id, 'info');
    }, 1500);
}

// عرض الإشعارات المتعلقة بالمزود
function browsmynotes(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض الإشعارات للمزود ' + id, 'info');
    }, 1000);
}

// عرض عمليات المزود
function browsopitems(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض التقارير للمزود ' + id, 'info');
    }, 1000);
}

// إعدادات التنبيه
function configureAlerts(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('ضبط إعدادات التنبيه للمزود ' + id, 'info');
    }, 1000);
}

// إعدادات الإيقاف
function configureSuspension(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('ضبط إعدادات الإيقاف للمزود ' + id, 'info');
    }, 1000);
}

// عرض جميع الشبكات
function showAllNetworks(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض جميع الشبكات للمزود ' + id, 'info');
    }, 1000);
}

// إضافة رصيد
function addCredit(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        // Reload the DataTable after adding credit
        $('#providersTable').DataTable().ajax.reload();
        showToast('إضافة رصيد للمزود ' + id, 'info');
    }, 1000);
}

// عرض العمليات المعلقة
function viewPending(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض العمليات المعلقة للمزود ' + id, 'info');
    }, 1000);
}

// عرض العمليات
function viewOperations(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض العمليات للمزود ' + id, 'info');
    }, 1000);
}

// عرض التقارير اليومية
function viewDaily(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض التقارير اليومية للمزود ' + id, 'info');
    }, 1000);
}

// عرض الإشعارات
function viewNotifications(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض الإشعارات للمزود ' + id, 'info');
    }, 1000);
}

// فتح التأمينات
function openInsurance(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('فتح التأمينات للمزود ' + id, 'info');
    }, 1000);
}

// عرض رصيد الحساب
function viewAccountBalance(id) {
    showLoader();
    setTimeout(() => {
        hideLoader();
        showToast('عرض رصيد الحساب للمزود ' + id, 'info');
    }, 1000);
}

// Function to show/hide detailed package options
function slminfo(elementId) {
    var element = $(elementId);
    if (element.is(':visible')) {
        element.hide();
    } else {
        element.show();
    }
}

// Helper function to get selected network data
function getSelectedNetworks() {
    return {
        networks: $('input[name="networks"]:checked').map(function() { return this.value; }).get(),
        mtnofferss: $('input[name="mtnofferss[]"]:checked').map(function() { return this.value; }).get(),
        srafahns: $('input[name="srafahns[]"]:checked').map(function() { return this.value; }).get()
    };
}

// Helper function to set network checkboxes based on saved data
function setNetworkCheckboxes(networkData) {
    // Clear all checkboxes first
    $('input[name="networks"]').prop('checked', false);
    $('input[name="mtnofferss[]"]').prop('checked', false);
    $('input[name="srafahns[]"]').prop('checked', false);
    
    // Set checkboxes based on network data
    if (networkData.networks) {
        networkData.networks.forEach(function(value) {
            $('input[name="networks"][value="' + value + '"]').prop('checked', true);
        });
    }
    
    if (networkData.mtnofferss) {
        networkData.mtnofferss.forEach(function(value) {
            $('input[name="mtnofferss[]"][value="' + value + '"]').prop('checked', true);
        });
    }
    
    if (networkData.srafahns) {
        networkData.srafahns.forEach(function(value) {
            $('input[name="srafahns[]"][value="' + value + '"]').prop('checked', true);
        });
    }
}