<div class="container">
    <h2>ViewBag.Title</h2>

    <ul class="nav nav-tabs">
        <li class="ViewBag.IsDashboardMenuActive"><a href="/dashboard">Dashboard</a></li>
        <li class="ViewBag.IsUserMenuActive"><a href="/user">User</a></li>
        <li class="ViewBag.IsSalaryMenuActive"><a href="/salary">Salary</a></li>
        <li class="ViewBag.IsRateMenuActive"><a href="/rate">Rate</a></li>
        <li class="ViewBag.IsPaymentMenuActive"><a href="/payment">Payment</a></li>
    </ul>
</div>

<div class="container" style="margin-top: 20px;">
    <div id="info-message" class="alert-success"></div>
    <div id="error-message" class="alert-danger"></div>
    <br/>

    <slot />
</div>

<!-- Scripts.Render("~/bundles/jquery")
<script src="Url.Content("~/Scripts/kayo.min.js")" type="text/javascript"></script>
RenderSection("scripts", required: false) -->