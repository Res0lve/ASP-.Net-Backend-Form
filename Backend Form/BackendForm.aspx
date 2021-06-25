<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicForm.aspx.cs" Inherits="Basic_Form.BasicForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section id="wrapper">
            <div class="row">
                <div class="col-1g-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-4 col-md-offset-4">
                                <h1>Basic Form</h1>
                            </div>
                        </header>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="First Name" runat="server" />
                                        <asp:TextBox ID="txtFirstName" runat="server" Enabled="true" CssClass="form-control input-sm" placeholder="First Name" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Last Name" runat="server" />
                                        <asp:TextBox ID="txtLastName" runat="server" Enabled="true" CssClass="form-control input-sm" placeholder="Last Name" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Phone Number" runat="server" />
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" Enabled="true" CssClass="form-control input-sm" placeholder="Phone Number" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Email" runat="server" />
                                        <asp:TextBox ID="txtEmail" runat="server" Enabled="true" CssClass="form-control input-sm" placeholder="Email" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Address" runat="server" />
                                        <asp:TextBox ID="txtAddress" runat="server" Enabled="true" CssClass="form-control input-sm" placeholder="Address" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="DOB" runat="server" />
                                        <asp:TextBox ID="txtDOB" runat="server" Enabled="true" TextMode="Date" CssClass="form-control input-sm" />
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="TextBoxDOBLabel" Text="Searched DOB" runat="server" />
                                        <asp:TextBox ID="TextBoxDOB" runat="server" Enabled="false" Visibility="false" CssClass="form-control input-sm" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Gender" runat="server" />
                                        <asp:RadioButtonList ID="txtGender" runat="server">
                                            <asp:ListItem Value="M" Text="Male" />
                                            <asp:ListItem Value="F" Text="Female" />
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="TextBoxGenderLabel" Text="Searched Gender" runat="server" />
                                        <asp:TextBox ID="TextBoxGender" runat="server" Enabled="false" Visibility="false" CssClass="form-control input-sm" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Button Text="Add" ID="btnadd" CssClass="btn btn-primary" Width="200px" runat="server" OnClick="btnadd_Click" />
                                <asp:Button Text="Edit" ID="btnedit" CssClass="btn btn-primary" Width="200px" runat="server" OnClick="btnedit_Click" />
                                <asp:Button Text="Search" ID="btnsearch" CssClass="btn btn-primary" Width="200px" runat="server" OnClick="btnsearch_Click1" />
                                <asp:Button Text="Delete" ID="btndelete" CssClass="btn btn-danger" Width="200px" runat="server" OnClick="btndelete_Click" />   
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
