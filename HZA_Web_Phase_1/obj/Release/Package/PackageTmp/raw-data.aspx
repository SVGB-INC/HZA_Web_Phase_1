<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="raw-data.aspx.cs" Inherits="HZA_Web_Phase_1.raw_data" EnableEventValidation="False" Async="True" %>


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

        .extraclass {
            background-color: white;
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
            <a class="navbar-brand me-lg-5" href="single-comp-search.aspx">
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
                            <img src="assets/img/team/user.jpg" class="card-img-top rounded-circle border-white" alt="User Name" />
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
                    <li class="nav-item active">
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
                                    <input type="text" class="form-control" id="topbarInputIconLeft" placeholder="Search" aria-label="Search" aria-describedby="topbar-addon">
                                </div>
                            </form>
                            <!-- / Search form -->
                        </div>
                        <!-- Navbar links -->
                        <ul class="navbar-nav align-items-center">
                            <li class="nav-item dropdown ms-lg-3">
                                <a class="nav-link dropdown-toggle pt-1 px-0" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <div class="media d-flex align-items-center">
                                        <img src="../../assets/img/team/user.jpg" class="avatar rounded-circle" alt="Image placeholder" />
                                        <i class="fas fa-caret-down ms-1 d-inline d-sm-none"></i>
                                        <div class="media-body ms-2 text-dark align-items-center d-none d-lg-block">
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
                                    <asp:Button ID="btnLogout" class="dropdown-item d-flex align-items-center" runat="server" Text="Log Out" OnClick="btnLogout_Click" />
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <hr class="text-white">

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
                                            <asp:Label ID="lbSingleZero" runat="server" Text="0000"></asp:Label>
                                        </h3>
                                    </div>
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
                                            <asp:Label ID="lbSingleCharges" runat="server" Text="0000"></asp:Label>
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-12 col-xl-9">
                    <div class="row">
                        <div class="col-12 mb-4">
                            <div class="form-group row gap-2 py-3">
                                <label for="dataDropDown" class="col-sm-2 col-form-label text-white">Choose Table</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="dataDropDown" runat="server" AutoPostBack="true" class="form-select" aria-label="Default select example" OnSelectedIndexChanged="dataChange"></asp:DropDownList>
                                </div>
                            </div>
                            <asp:Button ID="btnDownload" class="btn btn-gray-800 px-4" runat="server" Text="Download New Data" OnClick="btnDownload_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <div class="row" id="filtersNow" runat="server">
                        <div class="col-md-4 mb-3">
                            <label for="siccode" class="col-form-label text-white">SIC Code</label>
                            <asp:DropDownList ID="siccode" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cstatus" class="col-form-label text-white">Company Status</label>
                            <asp:DropDownList ID="cstatus" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="ccategory" class="col-form-label text-white">Company Category</label>
                            <asp:DropDownList ID="ccategory" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cCountry" class="col-form-label text-white">Company Country</label>
                            <asp:DropDownList ID="cCountry" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cNumMortCharges" class="col-form-label text-white">Company Mortgages NUMMORT Charges</label>
                            <asp:DropDownList ID="cNumMortCharges" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cNumMortOutstanding" class="col-form-label text-white">Company Mortgages NUMMORT Outstanding</label>
                            <asp:DropDownList ID="cNumMortOutstanding" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cNumMortSatisfied" class="col-form-label text-white">Company Mortgages NUMMORT Satisfied</label>
                            <asp:DropDownList ID="cNumMortSatisfied" runat="server" AutoPostBack="false" class="form-select" aria-label="Default select example"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cCompName" class="col-form-label text-white">Company Name</label>
                            <input type="text" name="ContactName" ID="cCompName" value="" runat="server" AutoPostBack="false" class="form-control" />
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cCompNum" class="col-form-label text-white">Company Number</label>
                            <input type="text" ID="cCompNum" value="" runat="server" AutoPostBack="false" class="form-control" />
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cAddress" class="col-form-label text-white">Reg Address</label>
                            <input type="text" ID="cAddress" value="" runat="server" AutoPostBack="false" class="form-control" />
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cPostTown" class="col-form-label text-white">Post Town</label>
                            <input type="text" ID="cPostTown" value="" runat="server" AutoPostBack="false" class="form-control" />
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cCounty" class="col-form-label text-white">County</label>
                            <input type="text" ID="cCounty" value="" runat="server" AutoPostBack="false" class="form-control" />
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="cPostCode" class="col-form-label text-white">Post Code</label>
                            <input type="text" ID="cPostCode" value="" runat="server" AutoPostBack="false" class="form-control" />
                        </div>
                    </div>
                    <div class="row" id="filtersNow2" runat="server">
                        <div class="col-md-4 mb-3">
                            <asp:Button ID="filterBTN" class="btn btn-gray-800 px-4" runat="server" Text="   Filter Data   " OnClick="btnFilter_Click" />
                        </div>
                    </div>


                    <div class="table-responsive w-100">
                        <asp:GridView ID="viewtab" runat="server" AutoGenerateColumns="true" class="table extraclass table-centered w-100 table-nowrap mb-0 rounded" AllowPaging="True" PageSize="20" OnPageIndexChanging="viewtab_PageIndexChanging">
                            <PagerStyle CssClass="PagerCSS" />
                            <%--<HeaderStyle BackColor="#39BAC1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="White" BorderColor="#66CCFF" ForeColor="#003366" />--%>
                        </asp:GridView>
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
</body>
</html>
