<%@ Page Title="Students" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="comp2084_lesson9.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Students</h2>

    <a href="student.aspx">Add a Student</a>
    <!-- Grid to contain students table -->
    <asp:GridView runat="server" ID="grdStudents" CssClass="table table-striped table-hover" 
        AutoGenerateColumns="false"  OnSorting="grdStudents_Sorting"
        OnRowDeleting="grdStudents_RowDeleting" DataKeyNames="StudentID" AllowSorting="true">
        <Columns>
            <%--student info columns--%>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" SortExpression="StudentID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" SortExpression="FirstMidName" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" />

            <%--edit column--%>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="StudentID"
                DataNavigateUrlFormatString="student.aspx?StudentID={0}" />

            <%--delete column--%>
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
