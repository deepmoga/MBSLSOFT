<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="inquiry.aspx.cs" Inherits="Auth_inquiry" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Enquiry
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <section class="form-horizontal col-md-8">
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">Date</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtdate" CssClass="form-control" runat="server"></asp:TextBox>

                <asp:CalendarExtender runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></asp:CalendarExtender>
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">Name</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">Father's Name</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtfname" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Contact</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtcontact" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Address</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Course</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlcourse" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">

            <label for="inputPassword3" class="col-sm-2 control-label">Follow Up</label>
            <div class="col-sm-10">
                <div class="col-md-6">

                    <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control">
                        <asp:ListItem>Select Type</asp:ListItem>
                        <asp:ListItem>Days</asp:ListItem>
                        <asp:ListItem>Months</asp:ListItem>
                        <asp:ListItem>Years</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtdays" CssClass="form-control" placeholder="No Of Days" runat="server"></asp:TextBox>
                </div>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="g" InitialValue="Select Type" ControlToValidate="ddltype" Text="Please Select Correct Value" ForeColor="Red" runat="server" ErrorMessage="Select Status"></asp:RequiredFieldValidator>

            </div>
        </div>
         <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Referred By</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtref" CssClass="form-control" runat="server" ></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Feedback</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtfeed" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
       <div class="form-group">
            <label for="inputPassword3" class="col-sm-2 control-label">Status</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control">
                    <asp:ListItem>Select Status</asp:ListItem>
                    <asp:ListItem>Interested</asp:ListItem>
                    <asp:ListItem>Not Interested</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="g" InitialValue="Select Status" ControlToValidate="ddlstatus" Text="Please Select status" ForeColor="Red" runat="server" ErrorMessage="Select Status"></asp:RequiredFieldValidator>
            </div>
        </div>
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
   
      <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="g" />
    </div>
  </div>
</section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

