// بيانات تسجيل دخول وهمية وثابتة للتحقق
        private const string VALID_USERNAME = "admin";
        private const string VALID_PASSWORD = "password123";

        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. التحقق من وجود Cookies عند تحميل الصفحة
            if (!IsPostBack)
            {
                // استرجاع الـ Cookie الذي يحمل بيانات الاعتماد
                HttpCookie authCookie = Request.Cookies["AuthInfo"];

                if (authCookie != null)
                {
                    // إذا كان الـ Cookie موجوداً، نقوم بفك تشفير البيانات (أو قراءتها مباشرة في هذا المثال البسيط)
                    string storedUsername = authCookie["Username"];
                    string storedPassword = authCookie["Password"];

                    // نتحقق من صحة البيانات المخزنة
                    if (storedUsername == VALID_USERNAME && storedPassword == VALID_PASSWORD)
                    {
                        ShowWelcomePanel(storedUsername);
                    }
                    else
                    {
                        // الـ Cookie فاسد أو خاطئ
                        lblMessage.Text = "تم العثور على Cookie قديم وغير صالح.";
                        ShowLoginPanel();
                    }
                }
                else
                {
                    // لا يوجد Cookie، نعرض لوحة تسجيل الدخول
                    ShowLoginPanel();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 2. التحقق من صحة البيانات المُدخلة
            if (username == VALID_USERNAME && password == VALID_PASSWORD)
            {
                lblMessage.Text = "تم تسجيل الدخول بنجاح.";

                // 3. تخزين Cookies إذا تم تحديد "تذكرني"
                if (chkRememberMe.Checked)
                {
                    // إنشاء Cookie جديد
                    HttpCookie authCookie = new HttpCookie("AuthInfo");

                    // تخزين اسم المستخدم وكلمة المرور بداخله (يُفضل تشفير البيانات الحساسة في بيئة حقيقية)
                    authCookie["Username"] = username;
                    authCookie["Password"] = password;

                    // جعل الـ Cookie دائمًا (Persistent) لمدة 30 يوم
                    authCookie.Expires = DateTime.Now.AddDays(30);

                    // إضافة الـ Cookie إلى استجابة السيرفر ليتم تخزينه في المتصفح
                    Response.Cookies.Add(authCookie);
                }

                // عرض لوحة الترحيب
                ShowWelcomePanel(username);
            }
            else
            {
                lblMessage.Text = "اسم المستخدم أو كلمة المرور غير صحيحين.";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // 4. حذف Cookies تسجيل الدخول
            HttpCookie authCookie = Request.Cookies["AuthInfo"];

            if (authCookie != null)
            {
                // لإجبار المتصفح على حذف الـ Cookie، نحدد تاريخ انتهاء صلاحيته في الماضي
                authCookie.Expires = DateTime.Now.AddDays(-1);

                // إضافة الـ Cookie بتاريخ انتهاء قديم إلى الاستجابة
                Response.Cookies.Add(authCookie);

                lblMessage.Text = "تم مسح Cookies تسجيل الدخول. يمكنك تسجيل الدخول مرة أخرى.";
            }
            else
            {
                lblMessage.Text = "لا يوجد Cookies لتسجيل الدخول لحذفها.";
            }

            // إظهار لوحة تسجيل الدخول مرة أخرى
            ShowLoginPanel();
        }

        // دوال مساعدة لتبديل عرض اللوحات
        private void ShowWelcomePanel(string username)
        {
            pnlLogin.Visible = false;
            pnlWelcome.Visible = true;
            lblWelcomeUser.Text = username;
        }

        private void ShowLoginPanel()
        {
            pnlLogin.Visible = true;
            pnlWelcome.Visible = false;
            lblWelcomeUser.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
