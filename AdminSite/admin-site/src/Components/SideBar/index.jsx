import React from 'react';
//import '@font';

export default function sideBar() {
    return (
        <div id="page-top">
            <div id="wrapper">

                <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

                    <a class="sidebar-brand d-flex align-items-center justify-content-center" href="#">
                        <div class="sidebar-brand-text mx-3">SB Admin <sup>2</sup></div>
                    </a>

                    <hr class="sidebar-divider my-0"></hr>

                    <li class="nav-item">
                        <a class="nav-link" asp-area="Admin" asp-controller="Admin/Dashboard" asp-action="Index">
                            <i class="fas fa-fw fa-tachometer-alt"></i>
                            <span>Dashboard </span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" asp-area="Admin" asp-controller="Admin/ListCategories" asp-action="Index">
                            <i class="fas fa-fw fa-tachometer-alt"></i>
                            <span>Categories </span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" asp-area="Admin" asp-controller="Admin/ListTags" asp-action="Index">
                            <i class="fas fa-fw fa-tachometer-alt"></i>
                            <span>Brands </span>
                        </a>
                    </li>

                    <hr class="sidebar-divider d-none d-md-block"></hr>

                </ul>
            </div>
        </div>

    )
}