#pragma checksum "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\Shared\_Layout2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "290d2e1d9f409ce024fd05ffd59cc9c0e1dbe75f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__Layout2), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Layout2.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\_ViewImports.cshtml"
using HospitalManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\_ViewImports.cshtml"
using HospitalManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\_ViewImports.cshtml"
using HospitalManagement.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"290d2e1d9f409ce024fd05ffd59cc9c0e1dbe75f", @"/Areas/Admin/Views/Shared/_Layout2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0978233c5c696d4e843524ca16be86b40447b4bf", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__Layout2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "290d2e1d9f409ce024fd05ffd59cc9c0e1dbe75f3781", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\">\r\n\r\n    <title>Evergreen Clinic</title>\r\n    <meta");
                BeginWriteAttribute("content", " content=\"", 197, "\"", 207, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"description\">\r\n    <meta");
                BeginWriteAttribute("content", " content=\"", 239, "\"", 249, 0);
                EndWriteAttribute();
                WriteLiteral(@" name=""keywords"">

    <!-- Favicons -->
    <link href=""/Home/img/apple-touch-icon.png"" rel=""icon"">
    <link href=""/Home/img/apple-touch-icon.png"" rel=""apple-touch-icon"">

    <!-- Google Fonts -->
    <link href=""https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Roboto:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i"" rel=""stylesheet"">

    <!-- Vendor CSS Files -->
    <link href=""/Home/vendor/fontawesome-free/css/all.min.css"" rel=""stylesheet"">
    <link href=""/Home/vendor/animate.css/animate.min.css"" rel=""stylesheet"">
    <link href=""/Home/vendor/aos/aos.css"" rel=""stylesheet"">
    <link href=""/Home/vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">
    <link href=""/Home/vendor/bootstrap-icons/bootstrap-icons.css"" rel=""stylesheet"">
    <link href=""/Home/vendor/boxicons/css/boxicons.min.css"" rel=""stylesheet"">
    <link href=""/Home/vendor/glightbox/css/glightbox.min.css"" rel=""stylesheet"">
    <link h");
                WriteLiteral("ref=\"/Home/vendor/swiper/swiper-bundle.min.css\" rel=\"stylesheet\">\r\n\r\n    <!-- Template Main CSS File -->\r\n    <link href=\"/Home/css/style.css\" rel=\"stylesheet\">\r\n    ");
#nullable restore
#line 31 "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\Shared\_Layout2.cshtml"
Write(await RenderSectionAsync("styles", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ======================================================== -->\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "290d2e1d9f409ce024fd05ffd59cc9c0e1dbe75f6926", async() => {
                WriteLiteral(@"

    <!-- ======= Top Bar ======= -->
    <div id=""topbar"" class=""d-flex align-items-center fixed-top"">
        <div class=""container d-flex align-items-center justify-content-center justify-content-md-between"">
            <div class=""align-items-center d-none d-md-flex"">
                <i class=""bi bi-clock""></i> Monday - Saturday, 8AM to 10PM
            </div>
            <div class=""d-flex align-items-center"">
                <i class=""bi bi-phone""></i> Call us now +1 5555 88888 88
            </div>
        </div>
    </div>

    <!-- ======= Header ======= -->
    <header id=""header"" class=""fixed-top"">
        <div class=""container d-flex align-items-center"">

            <a href=""index.html"" class=""logo me-auto""><img src=""/Home/img/logo2.png""");
                BeginWriteAttribute("alt", " alt=\"", 2347, "\"", 2353, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
            <!-- Uncomment below if you prefer to use an image logo -->
            <!-- <h1 class=""logo me-auto""><a href=""index.html"">Medicio</a></h1> -->

            <nav id=""navbar"" class=""navbar order-last order-lg-0"">
                <ul>
                    <li><a class=""nav-link scrollto "" href=""Index"">Home</a></li>
                    <li><a class=""nav-link scrollto"" href=""TestList"">Test_List</a></li>
                    <li><a class=""nav-link scrollto"" href=""DoctorList"">Doctor_List</a></li>
                    <li class=""dropdown"">
                        <a href=""#""><span>Appointment</span> <i class=""bi bi-chevron-down""></i></a>
                        <ul>
                            <li><a href=""ManageSchedule"">View_Appointment</a></li>
                            <li><a href=""AddPatient"">Take_Appointment</a></li>
                        </ul>
                    </li>
                    <li class=""dropdown"">
                        <a href=""#""><span>Account</span> <i clas");
                WriteLiteral(@"s=""bi bi-chevron-down""></i></a>
                        <ul>
                            <li><a href=""Login"">SignIn</a></li>
                            <li><a href=""Register"">Register</a></li>
                        </ul>
                    </li>
                </ul>
                <i class=""bi bi-list mobile-nav-toggle""></i>
            </nav><!-- .navbar -->
        </div>
    </header><!-- End Header -->
    <div class=""container"">
        <main role=""main"" class=""pb-3"">
            ");
#nullable restore
#line 83 "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\Shared\_Layout2.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </main>
    </div>
    <!-- ======= Footer ======= -->
    <footer id=""footer"">
        <div class=""footer-top"">
            <div class=""container"">
                <div class=""row"">

                    <div class=""col-lg-8 col-md-8"">
                        <div class=""footer-info"">
                            <h3>Evergreen Clinic</h3>
                            <p>
                                A108 Adam Street, NY 535022, USA<br><br>
                                <strong>Phone:</strong> +1 5589 55488 55<br>
                                <strong>Email:</strong> info@example.com<br>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""container"">
            <div class=""copyright"">
                &copy; Copyright <strong><span>Evergreen</span></strong>. All Rights Reserved
            </div>
        </div>
    </footer><!-- End Footer -->

    <di");
                WriteLiteral(@"v id=""preloader""></div>
    <a href=""#"" class=""back-to-top d-flex align-items-center justify-content-center""><i class=""bi bi-arrow-up-short""></i></a>

    <!-- Vendor JS Files -->
    <script src=""/Home/vendor/purecounter/purecounter_vanilla.js""></script>
    <script src=""/Home/vendor/aos/aos.js""></script>
    <script src=""/Home/vendor/bootstrap/js/bootstrap.bundle.min.js""></script>
    <script src=""/Home/vendor/glightbox/js/glightbox.min.js""></script>
    <script src=""/Home/vendor/swiper/swiper-bundle.min.js""></script>
    <script src=""/Home/vendor/php-email-form/validate.js""></script>
    <!-- jQuery -->
    <script src=""/Admin/plugins/jquery/jquery.min.js""></script>
    <!-- jQuery UI 1.11.4 -->
    <script src=""/Admin/plugins/jquery-ui/jquery-ui.min.js""></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button)
    </script>
    <!-- Sparkline -->
    <script src=""/Admin/plugins/sparklines/sparkline.j");
                WriteLiteral(@"s""></script>
    <!-- JQVMap -->
    <script src=""/Admin/plugins/jqvmap/jquery.vmap.min.js""></script>
    <script src=""/Admin/plugins/jqvmap/maps/jquery.vmap.usa.js""></script>
    <!-- jQuery Knob Chart -->
    <script src=""/Admin/plugins/jquery-knob/jquery.knob.min.js""></script>
    <!-- daterangepicker -->
    <script src=""/Admin/plugins/moment/moment.min.js""></script>
    <script src=""/Admin/plugins/daterangepicker/daterangepicker.js""></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src=""/Admin/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js""></script>
    <!-- Summernote -->
    <script src=""/Admin/plugins/summernote/summernote-bs4.min.js""></script>
    <!-- overlayScrollbars -->
    <script src=""/Admin/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js""></script>
    <!-- Template Main JS File -->
    <script src=""/Home/js/main.js""></script>
    ");
#nullable restore
#line 149 "C:\Users\User\Desktop\HospitalManagement\HospitalManagement\HospitalManagement\HospitalManagement\Areas\Admin\Views\Shared\_Layout2.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591