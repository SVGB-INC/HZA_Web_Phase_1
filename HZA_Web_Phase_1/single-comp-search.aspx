<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="single-comp-search.aspx.cs" Inherits="HZA_Web_Phase_1.single_comp_search" EnableEventValidation="False" Async="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Primary Meta Tags -->
    <title>HANKZARIHS Associates</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="120x120" href="assets/img/logo/Favicon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="assets/img/logo/Favicon.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="assets/img/logo/Favicon.png" />

    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link type="text/css" href="css/volt.css" rel="stylesheet" />

</head>
<body>
    <style type="text/css">
        .PagerCSS td {
            padding: 0;
        }

        .PagerCSS a, .PagerCSS span {
            padding: 5px;
            width: 100%;
            color: black;
            text-decoration: none;
            font-weight: bold;
            font-size: 12pt;
            display: flex;
            width: 2rem;
            height: 2rem;
            justify-content: center;
            align-content: center;
            border-radius: 50%;
            border: 1px solid transparent;
        }

        .PagerCSS span {
            border: 1px solid #AAE;
            text-shadow: 0 0 2rem rgba(0,0,0,0.5);
            color: #39bac1;
        }
    </style>

    <form runat="server">

        <nav class="navbar navbar-dark navbar-theme-primary px-4 col-12 d-lg-none">
            <a class="navbar-brand me-lg-5" href="single-comp-search.html">
                <img class="navbar-brand-dark" src="assets/img/logo/LOGO.png" alt="logo" />
                <img class="navbar-brand-light" src="assets/img/brand/dark.svg" alt="logo" />
            </a>
            <div class="d-flex align-items-center">
                <button class="navbar-toggler d-lg-none collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
            </div>
        </nav>

        <nav id="sidebarMenu" class="sidebar d-lg-block bg-gray-800 text-white collapse" data-simplebar>
            <div class="sidebar-inner px-2 pt-3">
                <div class="user-card d-flex d-md-none align-items-center justify-content-between justify-content-md-center pb-4">
                    <div class="d-flex align-items-center">
                        <div class="avatar-lg me-4">
                            <img src="../../assets/img/team/profile-picture-3.jpg" class="card-img-top rounded-circle border-white" alt="user image" />
                        </div>
                        <div class="d-block">
                            <h2 class="h5 mb-3">Hi, Jane</h2>
                            <a href="../../pages/examples/sign-in.aspx" class="btn btn-secondary btn-sm d-inline-flex align-items-center">
                                <svg class="icon icon-xxs me-1" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path></svg>
                                Sign Out
              </a>
                        </div>
                    </div>
                    <div class="collapse-close d-md-none">
                        <a href="#sidebarMenu" data-bs-toggle="collapse" data-bs-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="true" aria-label="Toggle navigation">
                            <svg class="icon icon-xs" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>
                        </a>
                    </div>
                </div>
                <ul class="nav flex-column pt-3 pt-md-0">
                    <li class="nav-item">
                        <a href="single-comp-search.aspx" class="d-flex align-items-center">
                            <img src="assets/img/logo/LOGO.png" alt="Volt Logo" />

                            <!-- <span class="mt-1 ms-1 sidebar-text">Volt Overview</span> -->
                        </a>
                    </li>
                    <li class="nav-item active">
                        <a href="single-comp-search.aspx" class="nav-link">
                            <span class="sidebar-icon">
                                <i class="far fa-building"></i>
                            </span>
                            <span class="sidebar-text">Single Company</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="multi-comp-search.aspx" class="nav-link">
                            <span class="sidebar-icon">
                                <i class="fas fa-city"></i>
                            </span>
                            <span class="sidebar-text">Multiple Company Search</span>
                        </a>
                    </li>
                   <li class="nav-item">
                        <a href="raw-data.aspx" class="nav-link">
                            <span class="sidebar-icon">
                                <i class="fas fa-city"></i>
                            </span>
                            <span class="sidebar-text">Raw Data</span>
                        </a>
                    </li>
                     <li class="nav-item">
                        <a href="searchFilter.aspx" class="nav-link">
                            <span class="sidebar-icon">
                                <i class="far fa-question-circle"></i>
                            </span>
                            <span class="sidebar-text">Filter Data Search</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="about-us.aspx" class="nav-link">
                            <span class="sidebar-icon">
                                <i class="far fa-question-circle"></i>
                            </span>
                            <span class="sidebar-text">About Us</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="addInfo.aspx" class="nav-link">
                            <span class="sidebar-icon">
                                <i class="far fa-question-circle"></i>
                            </span>
                            <span class="sidebar-text">Additional Information</span>
                        </a>
                    </li>
                </ul>
            </div>
        </nav>

        <main class="content" id="signinbg" runat="server">
            <nav class="navbar navbar-top navbar-expand navbar-dashboard navbar-dark ps-0 pe-2 pb-0">
                <div class="container-fluid px-0">
                    <div class="d-flex justify-content-between w-100" id="navbarSupportedContent">
                        <div class="d-flex align-items-center">
                            <!-- Search form -->
                            <form class="navbar-search form-inline" id="navbar-search-main">
                                <div class="input-group input-group-merge search-bar">
                                    <span class="input-group-text" id="topbar-addon">
                                        <svg class="icon icon-xs" x-description="Heroicon name: solid/search" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                            <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd"></path>
                                        </svg>
                                    </span>
                                    <input type="text" class="form-control" id="topbarInputIconLeft" placeholder="Search" aria-label="Search" aria-describedby="topbar-addon">
                                </div>
                            </form>
                            <!-- / Search form -->
                        </div>
                        <!-- Navbar links -->
                        <ul class="navbar-nav align-items-center">
                            <%--<li class="nav-item">
                            <a class="nav-link pt-1 px-0" href="#">
                                <!--<i class="far fa-question-circle fa-2x text-white"></i>-->
                                <svg width="20" height="20">
 
<circle cx="10" cy="10" r="10" fill="#fff"></circle>
  <text x="50%" y="50%" text-anchor="middle" fill="black" font-size="16px" font-family="Verdana" dy=".3em">?</text>
?
</svg>
                            </a>
                        </li>--%>

                            <%-- <li class="nav-item dropdown">
                            <a class="nav-link text-dark notification-bell unread dropdown-toggle" data-unread-notifications="true" href="#" role="button" data-bs-toggle="dropdown" data-bs-display="static" aria-expanded="false">
                                <svg class="icon icon-sm text-white" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M10 2a6 6 0 00-6 6v3.586l-.707.707A1 1 0 004 14h12a1 1 0 00.707-1.707L16 11.586V8a6 6 0 00-6-6zM10 18a3 3 0 01-3-3h6a3 3 0 01-3 3z"></path></svg>
                            </a>
                            <div class="dropdown-menu dropdown-menu-lg dropdown-menu-center mt-2 py-0">
                                <div class="list-group list-group-flush">
                                    <a href="#" class="text-center text-primary fw-bold border-bottom border-light py-3">Notifications</a>
                                    <a href="#" class="list-group-item list-group-item-action border-bottom">
                                        <div class="row align-items-center">
                                            <div class="col-auto">
                                                <!-- Avatar -->
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-1.jpg" class="avatar-md rounded">
                                            </div>
                                            <div class="col ps-0 ms-2">
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h4 class="h6 mb-0 text-small">Jose Leos</h4>
                                                    </div>
                                                    <div class="text-end">
                                                        <small class="text-danger">a few moments ago</small>
                                                    </div>
                                                </div>
                                                <p class="font-small mt-1 mb-0">Added you to an event "Project stand-up" tomorrow at 12:30 AM.</p>
                                            </div>
                                        </div>
                                    </a>
                                    <a href="#" class="list-group-item list-group-item-action border-bottom">
                                        <div class="row align-items-center">
                                            <div class="col-auto">
                                                <!-- Avatar -->
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-2.jpg" class="avatar-md rounded">
                                            </div>
                                            <div class="col ps-0 ms-2">
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h4 class="h6 mb-0 text-small">Neil Sims</h4>
                                                    </div>
                                                    <div class="text-end">
                                                        <small class="text-danger">2 hrs ago</small>
                                                    </div>
                                                </div>
                                                <p class="font-small mt-1 mb-0">You've been assigned a task for "Awesome new project".</p>
                                            </div>
                                        </div>
                                    </a>
                                    <a href="#" class="list-group-item list-group-item-action border-bottom">
                                        <div class="row align-items-center">
                                            <div class="col-auto">
                                                <!-- Avatar -->
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-3.jpg" class="avatar-md rounded">
                                            </div>
                                            <div class="col ps-0 m-2">
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h4 class="h6 mb-0 text-small">Roberta Casas</h4>
                                                    </div>
                                                    <div class="text-end">
                                                        <small>5 hrs ago</small>
                                                    </div>
                                                </div>
                                                <p class="font-small mt-1 mb-0">Tagged you in a document called "Financial plans",</p>
                                            </div>
                                        </div>
                                    </a>
                                    <a href="#" class="list-group-item list-group-item-action border-bottom">
                                        <div class="row align-items-center">
                                            <div class="col-auto">
                                                <!-- Avatar -->
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-4.jpg" class="avatar-md rounded">
                                            </div>
                                            <div class="col ps-0 ms-2">
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h4 class="h6 mb-0 text-small">Joseph Garth</h4>
                                                    </div>
                                                    <div class="text-end">
                                                        <small>1 d ago</small>
                                                    </div>
                                                </div>
                                                <p class="font-small mt-1 mb-0">New message: "Hey, what's up? All set for the presentation?"</p>
                                            </div>
                                        </div>
                                    </a>
                                    <a href="#" class="list-group-item list-group-item-action border-bottom">
                                        <div class="row align-items-center">
                                            <div class="col-auto">
                                                <!-- Avatar -->
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-5.jpg" class="avatar-md rounded">
                                            </div>
                                            <div class="col ps-0 ms-2">
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <asp:Label ID="userName" runat="server" class="h6 mb-0 text-small" Text="User Name"></asp:Label>
                                                    </div>
                                                    <div class="text-end">
                                                        <small>2 hrs ago</small>
                                                    </div>
                                                </div>
                                                <p class="font-small mt-1 mb-0">New message: "We need to improve the UI/UX for the landing page."</p>
                                            </div>
                                        </div>
                                    </a>
                                    <a href="#" class="dropdown-item text-center fw-bold rounded-bottom py-3">
                                        <svg class="icon icon-xxs text-gray-400 me-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                            <path d="M10 12a2 2 0 100-4 2 2 0 000 4z"></path><path fill-rule="evenodd" d="M.458 10C1.732 5.943 5.522 3 10 3s8.268 2.943 9.542 7c-1.274 4.057-5.064 7-9.542 7S1.732 14.057.458 10zM14 10a4 4 0 11-8 0 4 4 0 018 0z" clip-rule="evenodd"></path></svg>
                                        View all
              </a>
                                </div>
                            </div>
                        </li>--%>
                            <li class="nav-item dropdown ms-lg-3">
                                <a class="nav-link dropdown-toggle pt-1 px-0" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <div class="media d-flex align-items-center">
                                        <img src="../../assets/img/team/user.jpg" class="avatar rounded-circle" alt="Image placeholder" />
                                        <i class="fas fa-caret-down ms-1 d-inline d-sm-none"></i>
                                        <div class="media-body ms-2 text-dark align-items-center d-none d-lg-block">
                                            <%--<span class="mb-0 font-small fw-bold text-white">Bonnie Green</span>--%>
                                            <asp:Label ID="lbUserName" runat="server" class="mb-0 font-small fw-bold text-white" Text="User Name"></asp:Label>
                                            <i class="fas fa-caret-down ms-1"></i>
                                        </div>
                                    </div>
                                </a>
                                <div class="dropdown-menu dashboard-dropdown dropdown-menu-end mt-2 py-1">
                                    <a class="dropdown-item d-flex align-items-center" href="#">
                                        <svg class="dropdown-icon text-gray-400 me-2" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clip-rule="evenodd"></path></svg>
                                        My Profile
                  </a>
                                    <a class="dropdown-item d-flex align-items-center" href="#">
                                        <svg class="dropdown-icon text-gray-400 me-2" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M11.49 3.17c-.38-1.56-2.6-1.56-2.98 0a1.532 1.532 0 01-2.286.948c-1.372-.836-2.942.734-2.106 2.106.54.886.061 2.042-.947 2.287-1.561.379-1.561 2.6 0 2.978a1.532 1.532 0 01.947 2.287c-.836 1.372.734 2.942 2.106 2.106a1.532 1.532 0 012.287.947c.379 1.561 2.6 1.561 2.978 0a1.533 1.533 0 012.287-.947c1.372.836 2.942-.734 2.106-2.106a1.533 1.533 0 01.947-2.287c1.561-.379 1.561-2.6 0-2.978a1.532 1.532 0 01-.947-2.287c.836-1.372-.734-2.942-2.106-2.106a1.532 1.532 0 01-2.287-.947zM10 13a3 3 0 100-6 3 3 0 000 6z" clip-rule="evenodd"></path></svg>
                                        Settings
                  </a>

                                    <div role="separator" class="dropdown-divider my-1"></div>
                                    <%--<a class="dropdown-item d-flex align-items-center" href="#">
                                    <svg class="dropdown-icon text-danger me-2" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path></svg>
                                    Logout
                  </a>--%>
                                    <asp:Button ID="btnLogout" class="dropdown-item d-flex align-items-center" runat="server" Text="Log Out" OnClick="btnLogout_Click" />
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <hr class="text-white">

            <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

            <asp:Timer ID="Timer1" runat="server" Interval="15000" Enabled="false" OnTick="Timer1_Tick"></asp:Timer>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
                <ContentTemplate>

                    <div class="row mt-3">
                        <div class="col-12 mb-4">
                        </div>

                        <div class="col-12 col-sm-6 col-xl-4 mb-4">
                            <div class="card border-0 shadow">
                                <div class="card-body p-3 p-sm-1">
                                    <div class="row d-block d-xl-flex align-items-center">
                                        <div class="col-12 col-xl-5 text-xl-center mb-3 mb-xl-0 d-flex align-items-center justify-content-xl-center">
                                            <div class="icon-shape icon-shape-primary rounded me-4 me-sm-0">
                                                <svg class="icon" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                                    <path d="M13 6a3 3 0 11-6 0 3 3 0 016 0zM18 8a2 2 0 11-4 0 2 2 0 014 0zM14 15a4 4 0 00-8 0v3h8v-3zM6 8a2 2 0 11-4 0 2 2 0 014 0zM16 18v-3a5.972 5.972 0 00-.75-2.906A3.005 3.005 0 0119 15v3h-3zM4.75 12.094A5.973 5.973 0 004 15v3H1v-3a3 3 0 013.75-2.906z"></path></svg>
                                            </div>
                                            <div class="d-sm-none">
                                                <h2 class="h5">Total Companies</h2>
                                                <h3 class="fw-extrabold mb-1">345,678</h3>
                                            </div>
                                        </div>
                                        <div class="col-12 col-xl-7 px-xl-0">
                                            <div class="d-none d-sm-block">
                                                <h2 class="h6 text-gray-400 mb-0">Total Companies</h2>
                                                <h3 class="fw-extrabold mb-2">
                                                    <asp:Label ID="lbSingleTot" runat="server" Text="0000"></asp:Label>
                                                </h3>
                                            </div>

                                            <%-- <small class="d-flex align-items-center text-gray-500">Feb 1 - Apr 1,<svg class="icon icon-xxs text-gray-500 ms-2 me-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM4.332 8.027a6.012 6.012 0 011.912-2.706C6.512 5.73 6.974 6 7.5 6A1.5 1.5 0 019 7.5V8a2 2 0 004 0 2 2 0 011.523-1.943A5.977 5.977 0 0116 10c0 .34-.028.675-.083 1H15a2 2 0 00-2 2v2.197A5.973 5.973 0 0110 16v-2a2 2 0 00-2-2 2 2 0 01-2-2 2 2 0 00-1.668-1.973z" clip-rule="evenodd"></path></svg>
                                                USA
                  </small>
                                            <div class="small d-flex mt-1">
                                                <div>
                                                    Since last month
                                        <svg class="icon icon-xs text-success" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M14.707 12.707a1 1 0 01-1.414 0L10 9.414l-3.293 3.293a1 1 0 01-1.414-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 010 1.414z" clip-rule="evenodd"></path></svg><span class="text-success fw-bolder">22%</span>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-12 col-sm-6 col-xl-4 mb-4">
                            <div class="card border-0 shadow">
                                <div class="card-body p-3 p-sm-1">
                                    <div class="row d-block d-xl-flex align-items-center">
                                        <div class="col-12 col-xl-5 text-xl-center mb-3 mb-xl-0 d-flex align-items-center justify-content-xl-center">
                                            <div class="icon-shape icon-shape-secondary rounded me-4 me-sm-0">
                                                <svg class="icon" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                                    <path fill-rule="evenodd" d="M10 2a4 4 0 00-4 4v1H5a1 1 0 00-.994.89l-1 9A1 1 0 004 18h12a1 1 0 00.994-1.11l-1-9A1 1 0 0015 7h-1V6a4 4 0 00-4-4zm2 5V6a2 2 0 10-4 0v1h4zm-6 3a1 1 0 112 0 1 1 0 01-2 0zm7-1a1 1 0 100 2 1 1 0 000-2z" clip-rule="evenodd"></path></svg>
                                            </div>

                                            <div class="d-sm-none">
                                                <h2 class="fw-extrabold h5">Zero Charges</h2>
                                                <h3 class="mb-1">$43,594</h3>
                                            </div>
                                        </div>
                                        <div class="col-12 col-xl-7 px-xl-0">
                                            <div class="d-none d-sm-block">
                                                <h2 class="h6 text-gray-400 mb-0">Zero Charges</h2>
                                                <h3 class="fw-extrabold mb-2">
                                                    <asp:Label ID="lbSingleZero" runat="server" Text="0000"></asp:Label></h3>
                                            </div>

                                            <%--<small class="d-flex align-items-center text-gray-500">Feb 1 - Apr 1,
                   
                                    <svg class="icon icon-xxs text-gray-500 ms-2 me-1" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM4.332 8.027a6.012 6.012 0 011.912-2.706C6.512 5.73 6.974 6 7.5 6A1.5 1.5 0 019 7.5V8a2 2 0 004 0 2 2 0 011.523-1.943A5.977 5.977 0 0116 10c0 .34-.028.675-.083 1H15a2 2 0 00-2 2v2.197A5.973 5.973 0 0110 16v-2a2 2 0 00-2-2 2 2 0 01-2-2 2 2 0 00-1.668-1.973z" clip-rule="evenodd"></path></svg>
                                                GER
                  </small>
                                            <div class="small d-flex mt-1">
                                                <div>
                                                    Since last month
                                        <svg class="icon icon-xs text-danger" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg><span class="text-danger fw-bolder">2%</span>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-12 col-sm-6 col-xl-4 mb-4">
                            <div class="card border-0 shadow">
                                <div class="card-body p-3 p-sm-1">
                                    <div class="row d-block d-xl-flex align-items-center">
                                        <div class="col-12 col-xl-5 text-xl-center mb-3 mb-xl-0 d-flex align-items-center justify-content-xl-center">
                                            <div class="icon-shape icon-shape-tertiary rounded me-4 me-sm-0">
                                                <svg class="icon" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                                    <path fill-rule="evenodd" d="M3 3a1 1 0 000 2v8a2 2 0 002 2h2.586l-1.293 1.293a1 1 0 101.414 1.414L10 15.414l2.293 2.293a1 1 0 001.414-1.414L12.414 15H15a2 2 0 002-2V5a1 1 0 100-2H3zm11.707 4.707a1 1 0 00-1.414-1.414L10 9.586 8.707 8.293a1 1 0 00-1.414 0l-2 2a1 1 0 101.414 1.414L8 10.414l1.293 1.293a1 1 0 001.414 0l4-4z" clip-rule="evenodd"></path></svg>
                                            </div>

                                            <div class="d-sm-none">
                                                <h2 class="fw-extrabold h5">Charges</h2>
                                                <h3 class="mb-1">50.88%</h3>
                                            </div>
                                        </div>
                                        <div class="col-12 col-xl-7 px-xl-0">
                                            <div class="d-none d-sm-block">
                                                <h2 class="h6 text-gray-400 mb-0">Charges</h2>
                                                <h3 class="fw-extrabold mb-2">
                                                    <asp:Label ID="lbSingleCharges" runat="server" Text="0000"></asp:Label></h3>
                                            </div>
                                            <%-- <small class="text-gray-500">Feb 1 - Apr 1 </small>
                                            <div class="small d-flex mt-1">
                                                <div>
                                                    Since last month
                                        <svg class="icon icon-xs text-success" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                            <path fill-rule="evenodd" d="M14.707 12.707a1 1 0 01-1.414 0L10 9.414l-3.293 3.293a1 1 0 01-1.414-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 010 1.414z" clip-rule="evenodd"></path></svg><span class="text-success fw-bolder">4%</span>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row">
                <div class="col-12 mb-4">
                    <%--                <form runat="server">--%>
                    <!-- <div class="form-group row">
                  <label for="sic-code" class="col-sm-2 col-form-label">Enter SIC code</label>
                  <div class="col-sm-10">
                    <input type="text" class="form-control" id="sic-code" placeholder="Place SIC code Here!" />
                  </div>
                </div> -->

                    <div class="form-group row gap-2 py-3">
                        <label for="sic-code" class="col-sm-2 col-form-label text-white">Choose SIC code</label>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="sicList" runat="server" class="form-select" aria-label="Default select example">
                                <asp:ListItem Text="Choose an SIC Code" Value="NA"></asp:ListItem>
                                <asp:ListItem Text="41100: Property Developer" Value="41100"></asp:ListItem>
                                <asp:ListItem Text="41201: Construction of commercial buildings" Value="41201"></asp:ListItem>
                                <asp:ListItem Text="68100: Buying and selling of your own real estate" Value="68100"></asp:ListItem>
                                <asp:ListItem Text="68201: Renting and operating of housing real estate" Value="68201"></asp:ListItem>
                                <asp:ListItem Text="68209: Other letting and operating of own or leased real estate" Value="68209"></asp:ListItem>
                                <asp:ListItem Text="64110: Central banking" Value="64110"></asp:ListItem>
                                <asp:ListItem Text="64191: Banks" Value="64191"></asp:ListItem>
                                <asp:ListItem Text="64192: Building societies" Value="64192"></asp:ListItem>
                                <asp:ListItem Text="64209: Holding company in property sector" Value="64209"></asp:ListItem>
                                <asp:ListItem Text="64305: Activities of property unit trusts" Value="64305"></asp:ListItem>
                                <asp:ListItem Text="64306: Activities of real estate investment trusts" Value="64306"></asp:ListItem>
                                <asp:ListItem Text="64910: Financial leasing" Value="64910"></asp:ListItem>
                                <asp:ListItem Text="64921: Credit granting by non-deposit taking finance houses and other specialist consumer credit grantors" Value="64921"></asp:ListItem>
                                <asp:ListItem Text="64922: Activities of mortgage finance companies" Value="64922"></asp:ListItem>
                                <asp:ListItem Text="64929: Other credit granting n.e.c." Value="64929"></asp:ListItem>
                                <asp:ListItem Text="64991: Security dealing on own account" Value="64991"></asp:ListItem>
                                <asp:ListItem Text="64992: Factoring" Value="64992"></asp:ListItem>
                                <asp:ListItem Text="64999: Financial intermediation not elsewhere classified" Value="64999"></asp:ListItem>
                                <asp:ListItem Text="65300: Pension funding" Value="65300"></asp:ListItem>
                                <asp:ListItem Text="66190: Activities auxiliary to financial intermediation n.e.c." Value="66190"></asp:ListItem>
                                <asp:ListItem Text="66300: Fund management activities" Value="66300"></asp:ListItem>
                                <asp:ListItem Text="68310: Real estate agencies" Value="68310"></asp:ListItem>
                                <asp:ListItem Text="68320: Real estate management on a fee or contract basis" Value="68320"></asp:ListItem>
                                <asp:ListItem Text="98000: Residents property management" Value="98000"></asp:ListItem>
                            </asp:DropDownList>


                            <%-- <select class="form-select" aria-label="Default select example">
                                <option selected value="41100">41100: Property Developer</option>
                                <option value="41201">41201: Construction of commercial buildings</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </select>--%>
                        </div>
                        <div class="col-sm-2">
                            <%--<button type="submit" class="btn btn btn-gray-800 px-4">Search</button>--%>
                            <%--<button id="btnSearch" class="btn btn btn-gray-800 px-4">Search Now</button> OnClientClick="return false;" --%>
                            <asp:Button ID="btnSearch" class="btn btn btn-gray-800 px-4" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                    <%--</form>
            </div>--%>

                    <div class="col-12">
                        <%-- <div class="progress">
                            <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" style="width: 75%"></div>
                        </div>--%>
                    </div>
                    <div class="col-12">

                        <div style="margin-bottom: 1.5em;">
                            <asp:Label ID="LabelDrop" runat="server" Text="Choose No. of Results" Font-Bold="True"
                                ForeColor="#ffffff"></asp:Label>

                            <asp:DropDownList ID="DropDownListNew" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                <asp:ListItem Text="250" Value="250"></asp:ListItem>
                                <asp:ListItem Text="500" Value="500"></asp:ListItem>
                                <asp:ListItem Text="1000" Value="1000"></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <nav>
                            <div class="nav custom-tab nav-tabs" id="nav-tab" role="tablist" style="justify-content: start; align-items: center;">



                                <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">ZERO CHARGES</a>
                                <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">CHARGES</a>

                                <asp:UpdatePanel style="margin-left: 30px;" ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Label ID="lbMessage" runat="server" Style="color: white;" Text="Status Code: Ready"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>



                            </div>
                        </nav>
                        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                            <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                                <div class="card border-0 shadow mb-4">
                                    <div class="table-responsive w-100">

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:GridView ID="singleZeroTab" runat="server" AutoGenerateColumns="false" class="table table-centered w-100 table-nowrap mb-0 rounded" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView_PageIndexChanging">
                                                    <PagerStyle CssClass="PagerCSS" />
                                                    <Columns>
                                                        <%--<asp:BoundField HeaderText="Sr. No." DataField="srNO" />--%>
                                                        <asp:HyperLinkField HeaderText="Sr. No." DataTextField="srNO" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                        <asp:BoundField HeaderText="SIC Code" DataField="sicCodee" />
                                                        <%--<asp:BoundField HeaderText="Company Name" DataField="compName" />--%>
                                                        <asp:HyperLinkField HeaderText="Company Name" DataTextField="compName" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                        <%--<asp:BoundField HeaderText="Company Number" DataField="compNumberMain" />--%>
                                                        <asp:HyperLinkField HeaderText="Company Number" DataTextField="compNumberMain" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                        <asp:BoundField HeaderText="Registered Address" DataField="regAddress" />
                                                        <asp:BoundField HeaderText="Charges" DataField="charges_Main" />
                                                        <asp:BoundField HeaderText="Date Creation" DataField="dtCreate" />
                                                        <asp:BoundField HeaderText="Status" DataField="status_Main" />
                                                        <asp:BoundField HeaderText="Persons Entitled" DataField="pEntitle" />
                                                        <asp:BoundField HeaderText="Brief Description" DataField="desc" />
                                                        <asp:BoundField HeaderText="Charge Code" DataField="cCode" />
                                                        <%--<asp:BoundField HeaderText="Company Link" DataField="companyLink" />--%>
                                                        <asp:HyperLinkField HeaderText="Company Link" DataTextField="companyLink" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                                <div class="card border-0 shadow mb-4">
                                    <div class="table-responsive w-100">

                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:GridView ID="singleChargesTab" runat="server" AutoGenerateColumns="false" class="table table-centered w-100 table-nowrap mb-0 rounded" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridViewCharges_PageIndexChanging">
                                                    <PagerStyle CssClass="PagerCSS" />
                                                    <Columns>
                                                        <%--<asp:BoundField HeaderText="Sr. No." DataField="srNO" />--%>
                                                        <asp:HyperLinkField HeaderText="Sr. No." DataTextField="srNO" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                        <asp:BoundField HeaderText="SIC Code" DataField="sicCodee" />
                                                        <%--<asp:BoundField HeaderText="Company Name" DataField="compName" />--%>
                                                        <asp:HyperLinkField HeaderText="Company Name" DataTextField="compName" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                        <%--<asp:BoundField HeaderText="Company Number" DataField="compNumberMain" />--%>
                                                        <asp:HyperLinkField HeaderText="Company Number" DataTextField="compNumberMain" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                        <asp:BoundField HeaderText="Registered Address" DataField="regAddress" />
                                                        <asp:BoundField HeaderText="Charges" DataField="charges_Main" />
                                                        <asp:BoundField HeaderText="Date Creation" DataField="dtCreate" />
                                                        <asp:BoundField HeaderText="Status" DataField="status_Main" />
                                                        <asp:BoundField HeaderText="Persons Entitled" DataField="pEntitle" />
                                                        <asp:BoundField HeaderText="Brief Description" DataField="desc" />
                                                        <asp:BoundField HeaderText="Charge Code" DataField="cCode" />
                                                        <%--<asp:BoundField HeaderText="Company Link" DataField="companyLink" />--%>
                                                        <asp:HyperLinkField HeaderText="Company Link" DataTextField="companyLink" Target="_blank" ControlStyle-ForeColor="blue" ControlStyle-Font-Bold="true" ControlStyle-Font-Underline="true" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row gap-2 d-flex justify-content-between">
                        <div class="col-md-6 d-flex gap-1">
                            <asp:Button ID="btnPause" class="btn btn-gray-800 px-4 text-nowrap" runat="server" Text="Pause" OnClick="btnPause_Click" />
                            <asp:Button ID="btnResume" class="btn btn-gray-800 px-4 text-nowrap" runat="server" Text="Resume" OnClick="btnResume_Click" />
                            <asp:Button ID="btnStop" class="btn btn-gray-800 px-4 text-nowrap" runat="server" Text="Stop" OnClick="btnStop_Click" />
                        </div>
                        <div class="col-md-5 d-flex gap-1 justify-content-md-end">
                            <asp:Button ID="btnXLS" class="btn btn-gray-800 px-4 text-nowrap" runat="server" Text="Save to XLS" OnClick="btnXLS_Click" />
                            <asp:Button ID="btnPDF" class="btn btn-gray-800 px-4 text-nowrap" runat="server" Text="Save to PDF" OnClick="btnPDF_Click" />
                        </div>
                    </div>

                </div>

            </div>

            <footer class="rounded mt-5">
                <div class="row">
                    <div class="col-12 col-md-4 col-xl-6 mb-4 mb-md-0">
                        <p class="mb-0 text-center text-lg-start text-white">© 2019-<span class="current-year text-white"></span> <a class="text-white text-primary fw-normal" href="#" target="_blank">Lorem Ipsum</a></p>
                    </div>
                    <div class="col-12 col-md-8 col-xl-6 text-center text-lg-end text-white">Version 1.0</div>
                </div>
            </footer>
        </main>
    </form>


    <!-- js files -->
    <script src="../../vendor/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            setInterval(function () {
                GetCustomers();
            }, 1000);
        });
        function GetCustomers() {
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        var row;
        function OnSuccess(response) {
            var customers = response.d;
            if (row == null) {
                row = $("[id*=gvCustomers] tr:last-child").clone(true);
            }
            $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();
            if (customers.length > 0) {
                $.each(customers, function () {
                    $("td", row).eq(0).html($(this)[0].CustomerID);
                    $("td", row).eq(1).html($(this)[0].ContactName);
                    $("td", row).eq(2).html($(this)[0].City);
                    $("[id*=gvCustomers]").append(row);
                    row = $("[id*=gvCustomers] tr:last-child").clone(true);
                });
            } else {
                var empty_row = row.clone(true);
                $("td:first-child", empty_row).attr("colspan", $("td", row).length);
                $("td:first-child", empty_row).attr("align", "center");
                $("td:first-child", empty_row).html("No records found for the search criteria.");
                $("td", empty_row).not($("td:first-child", empty_row)).remove();
                $("[id*=gvCustomers]").append(empty_row);
            }
        };
    </script>--%>
</body>
</html>
