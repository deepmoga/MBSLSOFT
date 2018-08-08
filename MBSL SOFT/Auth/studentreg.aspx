<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="studentreg.aspx.cs" Inherits="Auth_studentreg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>





<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <script src="../jquery.js"></script>
    <%--<link href="../datepick.css" rel="stylesheet" />--%>
    <style type="text/css">
        .waitingdiv {
            background-color: #F5F8FA;
            border: 1px solid #5A768E;
            color: #333333;
            font-size: 93%;
            margin-bottom: 1em;
            margin-top: 0.2em;
            padding: 8px 12px;
            width: 8.4em;
        }

        .img2 {
            width: 250px;
            height: 200px;
            background-position: center center;
            background-size: cover;
            -webkit-box-shadow: 0 0 1px 1px rgba(0, 0, 0, .3);
            display: inline-block;
        }
        table#ctl00_cpmain_rdogender tr {
    display: inline;
}
    </style>
    <link href="css/bootstrap-imageupload.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Student Registration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">


    <div class="col-md-8">
        <div class="product">

            <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
            <section>

                <div class="form-group">

                    <div class="col-md-2">

                        <label>Date</label>
                    </div>
                    <div class="col-md-10">

                        <div class="input-group">
                            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control date"></asp:TextBox>
                            <cc1:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></cc1:CalendarExtender>
                        </div>

                    </div>




                </div>

                <asp:UpdatePanel ID="PnlUsrDetails" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="col-md-2">
                                <label>Roll No.</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Rollno" Text="*" SetFocusOnError="true" EnableClientScript="true" ControlToValidate="txtrollno" ValidationGroup="g"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-10">
                                <asp:Label ID="lblrollno" runat="server" Style="color: black; display: none" Text="" CssClass="form-control col-md-4" Width="150"></asp:Label>
                                <asp:TextBox ID="txtrollno" runat="server" CssClass="form-control" Width="50%" Enabled="true"></asp:TextBox>
                                <div id="checkusername" style="color: White; padding-left: 153px;" runat="server" visible="false">
                                    <asp:Image ID="imgstatus" runat="server" Width="17px" Height="17px" />
                                    <asp:Label ID="lblStatus" runat="server" Style="color: Black"></asp:Label>
                                    <div class="waitingdiv" id="loadingdiv" style="display: none; margin-left: 5.3em">
                                        <img src="images/css/load.gif" alt="Loading" />Please wait...
                                    </div>

                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="display: none" class="form-group">
                    <div class="col-md-2">
                        <label>Old Roll No.</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtoldrollno" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2">
                        <label>Name</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtname" Text="*" ValidationGroup="g" runat="server" ErrorMessage="Fill Name"
                            SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-10">

                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2">
                        <label>Date Of Birth</label>
                    </div>
                    <div class="col-md-10">
                        <div class="input-group">
                            <asp:TextBox ID="txtdob" placeholder="Click on icon" runat="server" CssClass="form-control "></asp:TextBox>

                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                Enabled="True" TargetControlID="txtdob" PopupButtonID="Image2" Format="dd/MM/yyyy" CssClass="cal"></cc1:CalendarExtender>
                            <span class="input-group-btn btn-default btn" style="padding: 6px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/auth/images/cal.png" Width="20" />
                            </span>
                        </div>



                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Email</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Gender</label>
                    </div>
                    <div class="col-md-10">
                          <div class="radio radio-primary">
                        <asp:RadioButtonList ID="rdogender" runat="server">
                            <asp:ListItem Selected="True">Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                            </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Father's Name</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtfather" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Address</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtaddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2">
                        <label>Phone</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtphone" Text="*" runat="server" ErrorMessage="Fill Phone"
                            ValidationGroup="g" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtphone" Text="*" ValidationGroup="g" ValidationExpression="[0-9]{10}" ErrorMessage="Exter Valid Phone no"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtphone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-md-2">
                        <label>Father's Phone</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtfphn" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>




                <div class="form-group" style="display:none">
                    <div class="col-md-2">
                        <label>Mother Tongue</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txttounge" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>+2 From</label>
                    </div>
                    <div class="col-md-10">
                        <div class="col-md-4">
                            <div class="checkbox checkbox-primary">
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                    <asp:ListItem>CBSE</asp:ListItem>
                                    <asp:ListItem>ICSE</asp:ListItem>
                                    <asp:ListItem>PSEB</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtother" CssClass="form-control" runat="server" placeholder="Others"></asp:TextBox>
                        </div>


                    </div>

                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Qualification</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtquali" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">

                        <label>Prior Coaching</label>
                    </div>
                    <div class="col-md-10">
                        <div class="radio radio-primary">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                <asp:ListItem Selected="True">Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>


                <div class="form-group" style="display:none">
                    <div class="col-md-2">
                        <label>Institute Name</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtinst" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Course</label>
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddlcourse" AutoPostBack="true" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged" Width="190px" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <div class="clr"></div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Admission Fees</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtFee" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Discount</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtdiscount" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Type</label>
                    </div>
                    <div class="col-md-10">
                        <div class="checkbox checkbox-primary">
                            <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                                <asp:ListItem>G.T</asp:ListItem>
                                <asp:ListItem>AC</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Referred By</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtrefer" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Date Of Joining</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtdoj" placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtdoj" ID="txtdoj_CalendarExtender"></cc1:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Course EndDate</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtenddate" placeholder="DD/MM/YYYY" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtenddate" ID="CalendarExtender2"></cc1:CalendarExtender>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="txtenddate" Text="*" runat="server" ErrorMessage="Fill Course Enddate"
                            ValidationGroup="g" SetFocusOnError="true" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Room</label>
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddlroom" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group" style="display:none">
                    <div class="col-md-2">
                        <label>Batch Timming</label>
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddltime" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>User Name</label>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtusername" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Password</label>

                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtpass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Remarks</label>

                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2">
                        <label>Student Pic</label>
                    </div>
                    <div class="col-md-10">

                        <asp:FileUpload ID="fileupload" runat="server" CssClass="fileupload23" ForeColor="#CCCCCC" />
                    </div>



                </div>

            </section>
            <asp:Button ID="btn1" runat="server" Text="Submit" OnClick="btn1_Click"
                ValidationGroup="g" CssClass="btn btn-success" />
            <asp:Button ID="btn2" runat="server" Text="Reset" OnClick="btn2_Click" CssClass="btn btn-danger" />
            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="true" ValidationGroup="g" HeaderText="Following Error Occurs....." DisplayMode="BulletList"
                ShowMessageBox="true" runat="server" />
        </div>


        <div class="detail">


            <div class="clr"></div>
            <div style="text-align: right; padding-right: 200px">
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <%-- <asp:Image ID="img23" CssClass="img2" runat="server" AlternateText="NO Image" /> --%>
        <input type="hidden" name="url-input">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
    <%--    <script src="../jquery.js"></script>
    <script src="../date.js"></script>--%>
    <script type="text/javascript">
        // When the document is ready
        $(document).ready(function () {

            $('.date').datepicker({
                format: "dd/mm/yyyy"
            });

        });
    </script>
    <script src="//code.jquery.com/jquery-1.12.2.min.js"></script>
    <script src="js/bootstrap-imageupload.js"></script>
    <script>
        $('.img-upload').imgupload({
            allowedFormats: ["jpg", "jpeg", "png", "gif"],
            previewWidth: 250,
            previewHeight: 250,
            maxFileSizeKb: 2048
        });
    </script>
    
</asp:Content>

