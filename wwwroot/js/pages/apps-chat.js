/**
 * Template Name: INSPINIA - Multipurpose Admin & Dashboard Template
 * By (Author): WebAppLayers
 * Module/App (File Name): Apps Chat
 * Version: 4.2.0
 */

class Chat {
    constructor({
                    sidebarSelector = '#chat-sidebar',
                    sidebarContactAttribute = 'data-chat-id',
                    sidebarContactSelector = `[${sidebarContactAttribute}]`,
                    searchSelector = '[data-chat-search]',
                    contentSelector = '[data-chat]',
                    inputSelector = '[data-chat-input]',
                    sendSelector = '[data-send]',
                    errorSelector = '[data-error]',
                    usernameSelector = '[data-chat-username]',
                    data = []
                } = {}) {
        this.sidebar = document.querySelector(sidebarSelector);
        this.sidebarContactAttribute = sidebarContactAttribute
        this.sidebarContactSelector = sidebarContactSelector
        this.searchInput = document.querySelector(searchSelector);
        this.chatContent = document.querySelector(contentSelector);
        this.chatInput = document.querySelector(inputSelector);
        this.sendButton = document.querySelector(sendSelector);
        this.errorElement = document.querySelector(errorSelector);
        this.usernameElement = document.querySelector(usernameSelector);
        this.activeChatId = null;
        this.chatData = Array.isArray(data) ? data : [];

        this.init();
    }

    init() {
        // Load first chat
        const defaultChat = this.chatData[0];

        this.setupSearch()

        // Sidebar click
        if (this.sidebar) {
            this.sidebar.addEventListener('click', (e) => {
                const link = e.target.closest(this.sidebarContactSelector);
                if (link) this.switchChat(link.dataset.chatId, link);
            });

            if (defaultChat) {
                const defaultEl = this.sidebar.querySelector(`[${this.sidebarContactAttribute}="${defaultChat.id}"]`);
                this.switchChat(defaultChat.id, defaultEl);
            }
        }

        // Send button click
        if (this.sendButton) {
            this.sendButton.addEventListener('click', () => this.sendMessage());
        }

        // Input "Enter" and enable/disable button
        if (this.chatInput) {
            this.chatInput.addEventListener('keypress', (e) => {
                if (e.key === 'Enter') {
                    e.preventDefault();
                    this.sendMessage();
                }
            });

            this.chatInput.addEventListener('input', () => {
                const text = this.chatInput.value.trim();
                this.sendButton.disabled = !text;

                if (this.errorElement && text) {
                    this.errorElement.classList.remove('d-block');
                    this.errorElement.classList.add('d-none');
                    if (this.errorTimeout) clearTimeout(this.errorTimeout);
                }
            });
        }

    }

    getChatById(id) {
        return this.chatData.find(c => c.id === id);
    }

    switchChat(chatId, clickedEl = null) {
        const chat = this.getChatById(chatId);
        if (!chat) return;

        this.activeChatId = chatId;
        this.renderMessages(chat.messages);

        // Highlight sidebar
        if (this.sidebar) {
            this.sidebar.querySelectorAll(this.sidebarContactSelector).forEach(el => el.classList.remove('active'));
        }
        if (clickedEl) clickedEl.classList.add('active');

        // Focus input
        this.chatInput?.focus();

        if (this.usernameElement) this.usernameElement.innerHTML = chat.contact.name

        setTimeout(() => {
            const simpleBar = window.SimpleBar?.instances?.get(this.chatContent);
            const scrollEl = simpleBar ? simpleBar.getScrollElement() : this.chatContent;
            scrollEl.scrollTop = scrollEl.scrollHeight;
        }, 50);
    }

    renderMessages(messages) {
        if (!messages || !this.chatContent) return;

        const simpleBar = window.SimpleBar?.instances?.get(this.chatContent);
        const scrollContent = simpleBar ? simpleBar.getContentElement() : this.chatContent;

        scrollContent.innerHTML = messages.map(msg => {
            const isSelf = msg.from === 'me';
            const alignment = isSelf ? 'text-end justify-content-end' : '';
            const bubbleClass = isSelf ? 'bg-info-subtle' : 'bg-warning-subtle';

            return `
                <div class="d-flex align-items-start gap-2 my-3 chat-item ${alignment}">
                    ${!isSelf ? `<img src="${msg.avatar}" class="avatar-md rounded-circle" alt="مستخدم">` : ''}
                    <div>
                        <div class="chat-message py-2 px-3 ${bubbleClass} rounded">${msg.text}</div>
                        <div class="text-muted fs-xs mt-1"><i class="ti ti-clock"></i> ${msg.time || ''}</div>
                    </div>
                    ${isSelf ? `<img src="${msg.avatar}" class="avatar-md rounded-circle" alt="مستخدم">` : ''}
                </div>
            `;
        }).join('');

        if (simpleBar) {
            simpleBar.recalculate();
            const el = simpleBar.getScrollElement();
            el.scrollTop = el.scrollHeight;
        } else {
            this.chatContent.scrollTop = this.chatContent.scrollHeight;
        }
    }

    sendMessage() {
        if (!this.chatInput || !this.activeChatId) return;

        const text = this.chatInput.value.trim();

        // Clear previous timeout
        if (this.errorTimeout) clearTimeout(this.errorTimeout);

        // Show error if empty
        if (!text) {
            if (this.errorElement) {
                this.errorElement.textContent = 'لا يمكن أن تكون الرسالة فارغة.';
                this.errorElement.classList.remove('d-none');
                this.errorElement.classList.add('d-block');

                // Auto-hide after 3 seconds
                this.errorTimeout = setTimeout(() => {
                    this.errorElement.classList.remove('d-block');
                    this.errorElement.classList.add('d-none');
                }, 3000);
            }
            return;
        }

        // Hide error if any
        if (this.errorElement) {
            this.errorElement.classList.remove('d-block');
            this.errorElement.classList.add('d-none');
        }

        const chat = this.getChatById(this.activeChatId);
        if (!chat) return;

        const now = new Date();
        const time = now.toLocaleTimeString([], {hour: '2-digit', minute: '2-digit'}).toLowerCase();

        const msg = {
            from: "me",
            text,
            time,
            avatar: "/images/users/user-2.jpg"
        };

        chat.messages.push(msg);
        this.renderMessages(chat.messages);
        this.chatInput.value = '';
        this.sendButton.disabled = true;

        this.simulateIncomingMessage(chat.id);
    }

    setupSearch() {
        if (this.searchInput) {
            this.searchInput.addEventListener('keyup', (e) => {
                const query = e.target.value.toLowerCase();

                const list = document.querySelector('.list-group');
                const items = list.querySelectorAll('.list-group-item');

                items.forEach(item => {
                    const fields = item.querySelectorAll('[data-chat-search-field]');
                    const match = [...fields].some(el => el.textContent.toLowerCase().includes(query));
                    item.style.setProperty('display', match ? '' : 'none', 'important');
                });

            });
        }
    }

    simulateIncomingMessage(chatId) {
        const chat = this.getChatById(chatId);
        if (!chat) return;

        const responses = [
            "لا يمكن الدردشة، المكالمات فقط",
            "😑😑😑",
            "👍",
            "شكراً!",
            "نتكلم لاحقاً.",
            "لا تقلق 😄",
            "أُعيد التحميل... ويعمل الآن. كل شيء أخضر ✅",
            "مفهوم!",
            "سأقوم بذلك!",
            "على الفور!",
            "تم!",
            "أقوم بالتحقق منها الآن",
            "ممتاز!",
            "سأعود إليك",
            "سأقوم بإصلاحه"
        ];

        const now = new Date();
        const time = now.toLocaleTimeString([], {hour: '2-digit', minute: '2-digit'}).toLowerCase();

        const reply = {
            from: chat.contact.name,
            text: responses[Math.floor(Math.random() * responses.length)],
            time,
            avatar: chat.contact.avatar
        };

        setTimeout(() => {
            chat.messages.push(reply);
            if (this.activeChatId === chatId) {
                this.renderMessages(chat.messages);
            }
        }, Math.random() * 2000 + 1000);
    }
}

const chatData = [
    {
        id: "chat1",
        contact: {
            name: "أفا ثومبسون",
            avatar: "/images/users/user-4.jpg"
        },
        messages: [
            {
                from: "أفا ثومبسون",
                text: "مرحباً! هل أنت متاح لمكالمة سريعة؟ 📞",
                time: "08:55 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "بالتأكيد، اعطني 5 دقائق. أقوم بإنهاء شيء ما.",
                time: "08:57 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أفا ثومبسون",
                text: "ممتاز. أخبرني عندما تكون جاهزًا 👍",
                time: "08:58 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "جاهز الآن. أتصل بك!",
                time: "09:00 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أفا ثومبسون",
                text: "شكراً لك على وقتك في وقتٍ سابق!",
                time: "09:45 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "على الرحب والسعة! كانت مناقشة منتجة.",
                time: "09:46 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أفا ثومبسون",
                text: "سأرسل الملفات المحدثة بحلول الظهر.",
                time: "09:50 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "رائع، سأقوم بمراجعتها بمجرد وصولها.",
                time: "09:52 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أفا ثومبسون",
                text: "أرسلتها للتو عبر درايف. أخبرني إذا كنت تواجه مشكلة في الوصول.",
                time: "12:03 م",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "حصلت عليها. كل شيء يبدو جيدًا حتى الآن!",
                time: "12:10 م",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أفا ثومبسون",
                text: "رائع 😊 أتطلع إلى ملاحظاتك!",
                time: "12:12 م",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "سأعود إليك بعد الغداء 🍴",
                time: "12:13 م",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أفا ثومبسون",
                text: "لا تستعجل، استمتع بوجبتك! 😄",
                time: "12:14 م",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "شكراً! نتحدث لاحقًا.",
                time: "12:15 م",
                avatar: "/images/users/user-2.jpg"
            }
        ]
    },
    {
        id: "chat2",
        contact: {
            name: "نوح سميث",
            avatar: "/images/users/user-5.jpg"
        },
        messages: [
            {
                from: "نوح سميث",
                text: "مرحباً، سؤال سريع—هل تحققت من نماذج التصميم الأخيرة؟",
                time: "10:05 ص",
                avatar: "/images/users/user-5.jpg"
            },
            {
                from: "me",
                text: "ليس بعد، أقوم بتسجيل الدخول الآن. هل تريد مني إعطاء الأولوية لذلك؟",
                time: "10:06 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "نوح سميث",
                text: "نعم من فضلك. أحتاج إلى ملاحظاتك قبل مراجعة العميل في الظهر.",
                time: "10:07 ص",
                avatar: "/images/users/user-5.jpg"
            },
            {
                from: "me",
                text: "مفهوم. سأقوم بمراجعتها وإرسال الملاحظات بعد قليل.",
                time: "10:08 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "نوح سميث",
                text: "شكراً جزيلاً!",
                time: "10:08 ص",
                avatar: "/images/users/user-5.jpg"
            },
            {
                from: "me",
                text: "الانطباع الأول: نظيف جداً. لكن هناك مشاكل طفيفة في التباعد.",
                time: "10:20 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "نوح سميث",
                text: "ملاحظ. أصلحها الآن.",
                time: "10:21 ص",
                avatar: "/images/users/user-5.jpg"
            },
            {
                from: "me",
                text: "أرسلت ملاحظات مفصلة عبر البريد الإلكتروني أيضًا 📬",
                time: "10:25 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "نوح سميث",
                text: "حصلت عليها. أقدر السرعة في الاستجابة!",
                time: "10:26 ص",
                avatar: "/images/users/user-5.jpg"
            }
        ]
    },
    {
        id: "chat3",
        contact: {
            name: "ليام جونسون",
            avatar: "/images/users/user-7.jpg"
        },
        messages: [
            {
                from: "ليام جونسون",
                text: "صباح الخير! هل قمت بتحديث نقاط النهاية في الخلفية؟",
                time: "09:15 ص",
                avatar: "/images/users/user-7.jpg"
            },
            {
                from: "me",
                text: "صباح النور! قمت للتو بدفع التغييرات إلى فرع التطوير.",
                time: "09:16 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ليام جونسون",
                text: "رائع، سأسحبها وأختبرها من جانبي.",
                time: "09:17 ص",
                avatar: "/images/users/user-7.jpg"
            },
            {
                from: "me",
                text: "أخبرني إذا تحطمت أي شيء ⚠️",
                time: "09:18 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ليام جونسون",
                text: "يبدو جيدًا حتى الآن. مجرد خطأ واحد في CORS.",
                time: "09:20 ص",
                avatar: "/images/users/user-7.jpg"
            },
            {
                from: "me",
                text: "آه، نسيت إدخال القائمة البيضاء. أصلحها الآن.",
                time: "09:21 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ليام جونسون",
                text: "أعد التحميل... ويعمل الآن. كل شيء أخضر ✅",
                time: "09:23 ص",
                avatar: "/images/users/user-7.jpg"
            },
            {
                from: "me",
                text: "جميل! هل يغطي ذلك جانبنا لهذا السبرينت إذن؟",
                time: "09:24 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ليام جونسون",
                text: "نعم. عمل جيد 💪",
                time: "09:25 ص",
                avatar: "/images/users/user-7.jpg"
            }
        ]
    },
    {
        id: "chat4",
        contact: {
            name: "إيما ويلسون",
            avatar: "/images/users/user-4.jpg"
        },
        messages: [
            {
                from: "إيما ويلسون",
                text: "مرحباً! هل أنت متاح لمكالمة سريعة؟ 📞",
                time: "08:55 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "بالتأكيد، اعطني 5 دقائق. أقوم بإنهاء شيء ما.",
                time: "08:57 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "إيما ويلسون",
                text: "ممتاز. أخبرني عندما تكون جاهزًا 👍",
                time: "08:58 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "جاهز الآن. أتصل بك!",
                time: "09:00 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "إيما ويلسون",
                text: "شكراً لك على وقتك في وقتٍ سابق!",
                time: "09:45 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "على الرحب والسعة! كانت مناقشة منتجة.",
                time: "09:46 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "إيما ويلسون",
                text: "سأرسل الملفات المحدثة بحلول الظهر.",
                time: "09:50 ص",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "رائع، سأقوم بمراجعتها بمجرد وصولها.",
                time: "09:52 ص",
                avatar: "/images/users/user-2.jpg"
            }
        ]
    },
    {
        id: "chat5",
        contact: {
            name: "أوليفيا مارتيز",
            avatar: "/images/users/user-8.jpg"
        },
        messages: [
            {
                from: "أوليفيا مارتيز",
                text: "شكراً جزيلاً!",
                time: "10:08 ص",
                avatar: "/images/users/user-8.jpg"
            },
            {
                from: "me",
                text: "الانطباع الأول: نظيف جداً. لكن هناك مشاكل طفيفة في التباعد.",
                time: "10:20 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أوليفيا مارتيز",
                text: "ملاحظ. أصلحها الآن.",
                time: "10:21 ص",
                avatar: "/images/users/user-8.jpg"
            },
            {
                from: "me",
                text: "أرسلت ملاحظات مفصلة عبر البريد الإلكتروني أيضًا 📬",
                time: "10:25 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "أوليفيا مارتيز",
                text: "حصلت عليها. أقدر السرعة في الاستجابة!",
                time: "10:26 ص",
                avatar: "/images/users/user-8.jpg"
            }
        ]
    },
    {
        id: "chat6",
        contact: {
            name: "ويليام ديفيس",
            avatar: "/images/users/user-7.jpg"
        },
        messages: [
            {
                from: "ويليام ديفيس",
                text: "يبدو جيدًا حتى الآن. مجرد خطأ واحد في CORS.",
                time: "09:20 ص",
                avatar: "/images/users/user-7.jpg"
            },
            {
                from: "me",
                text: "آه، نسيت إدخال القائمة البيضاء. أصلحها الآن.",
                time: "09:21 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ويليام ديفيس",
                text: "أعد التحميل... ويعمل الآن. كل شيء أخضر ✅",
                time: "09:23 ص",
                avatar: "/images/users/user-7.jpg"
            },
            {
                from: "me",
                text: "جميل! هل يغطي ذلك جانبنا لهذا السبرينت إذن؟",
                time: "09:24 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ويليام ديفيس",
                text: "نعم. عمل جيد 💪",
                time: "09:25 ص",
                avatar: "/images/users/user-7.jpg"
            }
        ]
    },
    {
        id: "chat7",
        contact: {
            name: "سوفيا مور",
            avatar: "/images/users/user-10.jpg"
        },
        messages: [
            {
                from: "me",
                text: "على الرحب والسعة! كانت مناقشة منتجة.",
                time: "09:46 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "سوفيا مور",
                text: "سأرسل الملفات المحدثة بحلول الظهر.",
                time: "09:50 ص",
                avatar: "/images/users/user-10.jpg"
            },
            {
                from: "me",
                text: "رائع، سأقوم بمراجعتها بمجرد وصولها.",
                time: "09:52 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "سوفيا مور",
                text: "أرسلتها للتو عبر درايف. أخبرني إذا كنت تواجه مشكلة في الوصول.",
                time: "12:03 م",
                avatar: "/images/users/user-10.jpg"
            },
            {
                from: "me",
                text: "حصلت عليها. كل شيء يبدو جيدًا حتى الآن!",
                time: "12:10 م",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "سوفيا مور",
                text: "رائع 😊 أتطلع إلى ملاحظاتك!",
                time: "12:12 م",
                avatar: "/images/users/user-10.jpg"
            },
            {
                from: "me",
                text: "سأعود إليك بعد الغداء 🍴",
                time: "12:13 م",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "سوفيا مور",
                text: "لا تستعجل، استمتع بوجبتك! 😄",
                time: "12:14 م",
                avatar: "/images/users/user-10.jpg"
            },
            {
                from: "me",
                text: "شكراً! نتحدث لاحقًا.",
                time: "12:15 م",
                avatar: "/images/users/user-2.jpg"
            }
        ]
    },
    {
        id: "chat8",
        contact: {
            name: "جاكسون لي",
            avatar: "/images/users/user-2.jpg"
        },
        messages: [
            {
                from: "جاكسون لي",
                text: "شكراً جزيلاً!",
                time: "10:08 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "me",
                text: "الانطباع الأول: نظيف جداً. لكن هناك مشاكل طفيفة في التباعد.",
                time: "10:20 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "جاكسون لي",
                text: "ملاحظ. أصلحها الآن.",
                time: "10:21 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "me",
                text: "أرسلت ملاحظات مفصلة عبر البريد الإلكتروني أيضًا 📬",
                time: "10:25 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "جاكسون لي",
                text: "حصلت عليها. أقدر السرعة في الاستجابة!",
                time: "10:26 ص",
                avatar: "/images/users/user-2.jpg"
            }
        ]
    },
    {
        id: "chat9",
        contact: {
            name: "كلوي أندرسون",
            avatar: "/images/users/user-3.jpg"
        },
        messages: [
            {
                from: "كلوي أندرسون",
                text: "يبدو جيدًا حتى الآن. مجرد خطأ واحد في CORS.",
                time: "09:20 ص",
                avatar: "/images/users/user-3.jpg"
            },
            {
                from: "me",
                text: "آه، نسيت إدخال القائمة البيضاء. أصلحها الآن.",
                time: "09:21 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "كلوي أندرسون",
                text: "أعد التحميل... ويعمل الآن. كل شيء أخضر ✅",
                time: "09:23 ص",
                avatar: "/images/users/user-3.jpg"
            },
            {
                from: "me",
                text: "جميل! هل يغطي ذلك جانبنا لهذا السبرينت إذن؟",
                time: "09:24 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "كلوي أندرسون",
                text: "نعم. عمل جيد 💪",
                time: "09:25 ص",
                avatar: "/images/users/user-3.jpg"
            }
        ]
    },
    {
        id: "chat10",
        contact: {
            name: "لوكاس رايت",
            avatar: "/images/users/user-4.jpg"
        },
        messages: [
            {
                from: "me",
                text: "رائع، سأقوم بمراجعتها بمجرد وصولها.",
                time: "09:52 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "لوكاس رايت",
                text: "أرسلتها للتو عبر درايف. أخبرني إذا كنت تواجه مشكلة في الوصول.",
                time: "12:03 م",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "حصلت عليها. كل شيء يبدو جيدًا حتى الآن!",
                time: "12:10 م",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "لوكاس رايت",
                text: "رائع 😊 أتطلع إلى ملاحظاتك!",
                time: "12:12 م",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "سأعود إليك بعد الغداء 🍴",
                time: "12:13 م",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "لوكاس رايت",
                text: "لا تستعجل، استمتع بوجبتك! 😄",
                time: "12:14 م",
                avatar: "/images/users/user-4.jpg"
            },
            {
                from: "me",
                text: "شكراً! نتحدث لاحقًا.",
                time: "12:15 م",
                avatar: "/images/users/user-2.jpg"
            }
        ]
    },
    {
        id: "chat11",
        contact: {
            name: "ميا سكوت",
            avatar: "/images/users/user-6.jpg"
        },
        messages: [
            {
                from: "me",
                text: "الانطباع الأول: نظيف جداً. لكن هناك مشاكل طفيفة في التباعد.",
                time: "10:20 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ميا سكوت",
                text: "ملاحظ. أصلحها الآن.",
                time: "10:21 ص",
                avatar: "/images/users/user-6.jpg"
            },
            {
                from: "me",
                text: "أرسلت ملاحظات مفصلة عبر البريد الإلكتروني أيضًا 📬",
                time: "10:25 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "ميا سكوت",
                text: "حصلت عليها. أقدر السرعة في الاستجابة!",
                time: "10:26 ص",
                avatar: "/images/users/user-6.jpg"
            }
        ]
    },
    {
        id: "chat12",
        contact: {
            name: "بينجامين كلارك",
            avatar: "/images/users/user-9.jpg"
        },
        messages: [
            {
                from: "بينجامين كلارك",
                text: "يبدو جيدًا حتى الآن. مجرد خطأ واحد في CORS.",
                time: "09:20 ص",
                avatar: "/images/users/user-9.jpg"
            },
            {
                from: "me",
                text: "آه، نسيت إدخال القائمة البيضاء. أصلحها الآن.",
                time: "09:21 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "بينجامين كلارك",
                text: "أعد التحميل... ويعمل الآن. كل شيء أخضر ✅",
                time: "09:23 ص",
                avatar: "/images/users/user-9.jpg"
            },
            {
                from: "me",
                text: "جميل! هل يغطي ذلك جانبنا لهذا السبرينت إذن؟",
                time: "09:24 ص",
                avatar: "/images/users/user-2.jpg"
            },
            {
                from: "بينجامين كلارك",
                text: "نعم. عمل جيد 💪",
                time: "09:25 ص",
                avatar: "/images/users/user-9.jpg"
            }
        ]
    },
];

document.addEventListener("DOMContentLoaded", () => {
    new Chat({
        data: chatData
    });
})