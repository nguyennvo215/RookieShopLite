import React from 'react';
//import '@font';

export default function sideBar() {
    return(
    <div id="wrapper">

        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.html">
                <div class="sidebar-brand-icon rotate-n-15">
                    {/* <i class="fas fa-laugh-wink"></i> */}
                    {/* <FontAwesomeIcon icon={['fas', 'fa-laugh-wink']} /> */}
                </div>
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
                    <span>ListCategories </span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" asp-area="Admin" asp-controller="Admin/ListTags" asp-action="Index">
                    <i class="fas fa-fw fa-tachometer-alt"></i>
                    <span>ListTags</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" asp-area="Admin" asp-controller="Admin/ListTags_Posts" asp-action="Index">
                    <i class="fas fa-fw fa-tachometer-alt"></i>
                    <span>ListTags_Posts</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" asp-area="Admin" asp-controller="Admin/ListUser" asp-action="Index">
                    <i class="fas fa-fw fa-tachometer-alt"></i>
                    <span>ListUsers</span>
                </a>
            </li>

            <hr class="sidebar-divider d-none d-md-block"></hr>

            <div class="text-center d-none d-md-inline">
                <button class="rounded-circle border-0" id="sidebarToggle"></button>
            </div>

        </ul>
    </div>
    )
}