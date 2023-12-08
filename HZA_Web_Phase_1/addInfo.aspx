<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="addInfo.aspx.cs" Inherits="HZA_Web_Phase_1.addInfo" EnableEventValidation="False" Async="True" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Primary Meta Tags -->
    <title>HANKZARIHS Associates</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="120x120" href="assets/img/logo/Favicon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="assets/img/logo/Favicon.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="assets/img/logo/Favicon.png" />

    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link type="text/css" href="css/style.css" rel="stylesheet" />
</head>

<body>
    <!-- NOTICE: You can use the _analytics.html partial to include production code specific code & trackers -->

    <nav class="navbar navbar-dark navbar-theme-primary px-4 col-12 d-lg-none">
        <a class="navbar-brand me-lg-5" href="single-comp-search.php">
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
                        <img src="../../assets/img/team/profile-picture-3.jpg" class="card-img-top rounded-circle border-white" alt="Bonnie Green" />
                    </div>
                    <div class="d-block">
                        <h2 class="h5 mb-3">Hi, Jane</h2>
                        <a href="../../pages/examples/sign-in.html" class="btn btn-secondary btn-sm d-inline-flex align-items-center">
                            <svg class="icon icon-xxs me-1" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path>
                            </svg>
                            Sign Out
                        </a>
                    </div>
                </div>
                <div class="collapse-close d-md-none">
                    <a href="#sidebarMenu" data-bs-toggle="collapse" data-bs-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="true" aria-label="Toggle navigation">
                        <svg class="icon icon-xs" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path>
                        </svg>
                    </a>
                </div>
            </div>
            <ul class="nav flex-column pt-3 pt-md-0">
                <li class="nav-item">
                    <a href="single-comp-search.aspx" class="d-flex align-items-center">
                        <img src="assets/img/logo/LOGO.png" alt="Logo" />
                    </a>
                </li>
                <li class="nav-item">
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
                <li class="nav-item active">
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

    <main class="content" id="signinbg">
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
                                <input type="text" class="form-control" id="topbarInputIconLeft" placeholder="Search" aria-label="Search" aria-describedby="topbar-addon" />
                            </div>
                        </form>
                        <!-- / Search form -->
                    </div>
                    <!-- Navbar links -->
                    <ul class="navbar-nav align-items-center">
                        <li class="nav-item">
                            <a class="nav-link pt-1 px-0" href="#">
                                <!--<i class="far fa-question-circle fa-2x text-white"></i>-->
                                <svg width="20" height="20">
                    <circle cx="10" cy="10" r="10" fill="#fff"></circle>
                    <text x="50%" y="50%" text-anchor="middle" fill="black" font-size="16px" font-family="Verdana" dy=".3em">?</text>
                    ?
                  </svg>
                            </a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link text-dark notification-bell unread dropdown-toggle" data-unread-notifications="true" href="#" role="button" data-bs-toggle="dropdown" data-bs-display="static" aria-expanded="false">
                                <svg class="icon icon-sm text-white" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M10 2a6 6 0 00-6 6v3.586l-.707.707A1 1 0 004 14h12a1 1 0 00.707-1.707L16 11.586V8a6 6 0 00-6-6zM10 18a3 3 0 01-3-3h6a3 3 0 01-3 3z"></path>
                                </svg>
                            </a>
                            <div class="dropdown-menu dropdown-menu-lg dropdown-menu-center mt-2 py-0">
                                <div class="list-group list-group-flush">
                                    <a href="#" class="text-center text-primary fw-bold border-bottom border-light py-3">Notifications</a>
                                    <a href="#" class="list-group-item list-group-item-action border-bottom">
                                        <div class="row align-items-center">
                                            <div class="col-auto">
                                                <!-- Avatar -->
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-1.jpg" class="avatar-md rounded" />
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
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-2.jpg" class="avatar-md rounded" />
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
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-3.jpg" class="avatar-md rounded" />
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
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-4.jpg" class="avatar-md rounded" />
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
                                                <img alt="Image placeholder" src="../../assets/img/team/profile-picture-5.jpg" class="avatar-md rounded" />
                                            </div>
                                            <div class="col ps-0 ms-2">
                                                <div class="d-flex justify-content-between align-items-center">
                                                    <div>
                                                        <h4 class="h6 mb-0 text-small">Bonnie Green</h4>
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
                                            <path d="M10 12a2 2 0 100-4 2 2 0 000 4z"></path>
                                            <path fill-rule="evenodd" d="M.458 10C1.732 5.943 5.522 3 10 3s8.268 2.943 9.542 7c-1.274 4.057-5.064 7-9.542 7S1.732 14.057.458 10zM14 10a4 4 0 11-8 0 4 4 0 018 0z" clip-rule="evenodd"></path>
                                        </svg>
                                        View all
                                    </a>
                                </div>
                            </div>
                        </li>
                        <li class="nav-item dropdown ms-lg-3">
                            <a class="nav-link dropdown-toggle pt-1 px-0" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <div class="media d-flex align-items-center">
                                    <img class="avatar rounded-circle" alt="Image placeholder" src="assets/img/team/profile-picture-3.jpg" />
                                    <i class="fas fa-caret-down ms-1 d-inline d-sm-none"></i>
                                    <div class="media-body ms-2 text-dark align-items-center d-none d-lg-block">
                                        <span class="mb-0 font-small fw-bold text-white">Bonnie Green</span>
                                        <i class="fas fa-caret-down ms-1"></i>
                                    </div>
                                </div>
                            </a>
                            <div class="dropdown-menu dashboard-dropdown dropdown-menu-end mt-2 py-1">
                                <a class="dropdown-item d-flex align-items-center" href="#">
                                    <svg class="dropdown-icon text-gray-400 me-2" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.986 5.986 0 0010 16a5.986 5.986 0 004.546-2.084A5 5 0 0010 11z" clip-rule="evenodd"></path>
                                    </svg>
                                    My Profile
                                </a>
                                <a class="dropdown-item d-flex align-items-center" href="#">
                                    <svg class="dropdown-icon text-gray-400 me-2" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M11.49 3.17c-.38-1.56-2.6-1.56-2.98 0a1.532 1.532 0 01-2.286.948c-1.372-.836-2.942.734-2.106 2.106.54.886.061 2.042-.947 2.287-1.561.379-1.561 2.6 0 2.978a1.532 1.532 0 01.947 2.287c-.836 1.372.734 2.942 2.106 2.106a1.532 1.532 0 012.287.947c.379 1.561 2.6 1.561 2.978 0a1.533 1.533 0 012.287-.947c1.372.836 2.942-.734 2.106-2.106a1.533 1.533 0 01.947-2.287c1.561-.379 1.561-2.6 0-2.978a1.532 1.532 0 01-.947-2.287c.836-1.372-.734-2.942-2.106-2.106a1.532 1.532 0 01-2.287-.947zM10 13a3 3 0 100-6 3 3 0 000 6z" clip-rule="evenodd"></path>
                                    </svg>
                                    Settings
                                </a>

                                <div role="separator" class="dropdown-divider my-1"></div>
                                <a class="dropdown-item d-flex align-items-center" href="logout.php">
                                    <svg class="dropdown-icon text-danger me-2" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path>
                                    </svg>
                                    Logout
                                </a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <hr class="text-white" />

        <div class="col-12">
            <h1 class="heading">Advanced Information</h1>
        </div>
        <div class="col-12">
            <nav>
                <div class="nav nav-tabs" id="nav-tab" role="tablist">
                    <a class="tab-list nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-Summary" role="tab" aria-controls="nav-home" aria-selected="true">Summary</a>
                    <a class="tab-list nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-Contact" role="tab" aria-controls="nav-profile" aria-selected="false">Contact</a>
                    <a class="tab-list nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-People" role="tab" aria-controls="nav-profile" aria-selected="false">People</a>
                    <a class="tab-list nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-Charge" role="tab" aria-controls="nav-profile" aria-selected="false">Charge</a>
                    <a class="tab-list nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-Land-Registry" role="tab" aria-controls="nav-profile" aria-selected="false">Land Registry</a>
                    <a class="tab-list nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-Research" role="tab" aria-controls="nav-profile" aria-selected="false">Research </a>
                    <a class="tab-list nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-Insights   " role="tab" aria-controls="nav-profile" aria-selected="false">Insights </a>
                </div>
            </nav>

            <%--Main tabs--%>
            <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                <div class="tab-pane fade show active" id="nav-Summary" role="tabpanel" aria-labelledby="nav-home-tab">
                    <div class="main">
                        <div class="sides">
                            <div class="tables">
                                <h2>Summary</h2>
                                <div class="group">
                                    <div class="el headings">Company Number</div>
                                    <%--<div class="el">Link to credit safe</div>--%>
                                    <asp:Label ID="lb_summary_CompNumb" runat="server" class="el" Text="Company Number"></asp:Label>
                                </div>
                                <div class="group">
                                    <div class="el headings">Company Name</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_summary_CompName" runat="server" class="el" Text="Company Name"></asp:Label>
                                </div>
                                <div class="group">
                                    <div class="el headings">All Titles</div>
                                    <div class="el">propertydata.api</div>
                                </div>
                            </div>
                        </div>
                        <div class="sides">
                            <div class="tables">
                                <h2>Summary</h2>
                                <div class="group">
                                    <div class="el headings">Sic Code</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_summary_sicCode" runat="server" class="el" Text="SIC Code"></asp:Label>
                                </div>
                                <div class="group">
                                    <div class="el headings">Sic Description</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_summary_sicDesc" runat="server" class="el" Text="SIC Desc"></asp:Label>

                                </div>
                                <div class="group">
                                    <div class="el headings">Registered Address</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_summary_compAddress" runat="server" class="el" Text="Company Address"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="nav-Contact" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <div class="main">
                        <div class="sides">
                            <div class="tables">
                                <h2>Contact Details</h2>
                                <div class="group">
                                    <div class="el headings">Trading address</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_contact_tradeAddress" runat="server" class="el" Text="Trading Address"></asp:Label>
                                </div>
                                <div class="group">
                                    <div class="el headings">Street view</div>
                                    <div class="el">Unavailable</div>
                                </div>
                                <!-- <div class="group">
                    <div class="el headings">All Titles</div>
                    <div class="el">company house API</div>
                  </div> -->
                            </div>
                        </div>
                        <div class="sides">
                            <div class="tables">
                                <h2>Contact Details</h2>
                                <div class="group">
                                    <div class="el headings">company email</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_contact_email" runat="server" class="el" Text="Company Email"></asp:Label>
                                </div>
                                <div class="group">
                                    <div class="el headings">Tel Number</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_contact_tel" runat="server" class="el" Text="Telephone Number"></asp:Label>
                                </div>
                                <div class="group">
                                    <div class="el headings">website</div>
                                    <%--<div class="el">company house API</div>--%>
                                    <asp:Label ID="lb_contact_website" runat="server" class="el" Text="Website"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--directors tab--%>

                <div class="tab-pane fade" id="nav-People" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <asp:PlaceHolder ID="newPeople" runat="server"></asp:PlaceHolder>
                </div>
                <%--</div>--%>


                <%--charges tab--%>
                <div class="tab-pane fade" id="nav-Charge" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <asp:PlaceHolder ID="newCharges" runat="server"></asp:PlaceHolder>
                </div>


                <%--Land Registry Tab --%>

                <div class="tab-pane fade" id="nav-Land-Registry" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <div class="main">
                        <div class="sides">
                            <div class="tables">
                                <h2>Title</h2>
                                <div class="group">
                                    <div class="el headings">Data</div>
                                    <div class="el">API Dump Data</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Title number</div>
                                    <div class="el">DTR365201</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Tenure</div>
                                    <div class="el">Leasehold</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Property address</div>
                                    <div class="el">Land lying to the south</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">District</div>
                                    <div class="el">Bournemouth</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">County</div>
                                    <div class="el">Bournemouth</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Region</div>
                                    <div class="el">South West</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Postcode</div>
                                    <div class="el">NA</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Multiple address indicator</div>
                                    <div class="el">NA</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Price paid</div>
                                    <div class="el">NA</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Proprietor name</div>
                                    <div class="el">Sopley View Freehold Limited</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Company registration number</div>
                                    <div class="el">9999999</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Proprietorship category</div>
                                    <div class="el">Limited Company or Public</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Proprietor address</div>
                                    <div class="el">21 Norfolk Grange</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">NA</div>
                                    <div class="el">Bournemouth</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">NA</div>
                                    <div class="el">BH56 8UT</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Date proprietor added</div>
                                    <div class="el">41176</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Additional proprietor indicator</div>
                                    <div class="el">N</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Change indicator (change only update)</div>
                                    <div class="el">A</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Change date</div>
                                    <div class="el">43724</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--Research tab--%>

                <div class="tab-pane fade" id="nav-Research" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <asp:PlaceHolder ID="newResearch" runat="server"></asp:PlaceHolder>
                </div>

                <%--Insights Tab--%>

                <div class="tab-pane fade" id="nav-Insights" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <div class="main">
                        <div class="sides">
                            <div class="tables">
                                <h2>Title</h2>
                                <div class="group">
                                    <div class="el headings">Current lender</div>
                                    <div class="el">Shawbrook</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Product</div>
                                    <div class="el">Bridge</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Original Price Paid</div>
                                    <div class="el">650000</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Original LTV</div>
                                    <div class="el">75%</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Original Loan amount</div>
                                    <div class="el">487500</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Original Price Date</div>
                                    <div class="el">10/1/2021</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Potential date of redemption</div>
                                    <div class="el">10/1/2022</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">WAULT</div>
                                    <div class="el">na</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">CMV</div>
                                    <div class="el">950000</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">CMV 180</div>
                                    <div class="el">950000</div>
                                </div>

                                <div class="group">
                                    <div class="el headings">Credit Rating</div>
                                    <div class="el">good</div>
                                </div>
                                <div class="group">
                                    <div class="el headings">Planning Status</div>
                                    <div class="el">conversion to 6 flats</div>
                                </div>

                                <div class="group">
                                    <div class="el headings">Planning Key Dates</div>
                                    <div class="el">NA</div>
                                </div>

                                <div class="group">
                                    <div class="el headings">Contact details</div>
                                    <div class="el">NA</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row gap-2 d-flex justify-content-between">
                <div class="col-md-6 d-flex gap-1"></div>
                <div class="col-md-5 d-flex gap-1 justify-content-md-end">
                    <button type="submit" class="btn btn-gray-800 px-4 text-nowrap">Save to XLS</button>
                    <button type="submit" class="btn btn-gray-800 px-4 text-nowrap">Save to PDF</button>
                </div>
            </div>
        </div>

        <footer class="rounded mt-5">
            <div class="row">
                <div class="col-12 col-md-4 col-xl-6 mb-4 mb-md-0">
                    <p class="mb-0 text-center text-lg-start text-white">
                        © 2019-<span class="current-year text-white"></span>
                        <a class="text-white text-primary fw-normal" href="#" target="_blank">Lorem Ipsum</a>
                    </p>
                </div>
                <div class="col-12 col-md-8 col-xl-6 text-center text-lg-end text-white">Version 1.0</div>
            </div>
        </footer>
    </main>
    <!-- js files -->
    <script src="../../vendor/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</body>
</html>
