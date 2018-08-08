<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            width: 97px;
        }
        .auto-style3 {
            width: 211px;
        }
        .auto-style4 {
            width: 200px;
            text-align:right;
        }
        .auto-style5 {
            width: 66px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="TextBox1" PopupButtonID="TextBox1"></ajaxToolkit:CalendarExtender>
           </div>
        <div style="width: 725px; height: 380px;padding:20px;    color: black;border: 1px solid;">
                                    <table style="width: 100%;">
                                        <tr style="text-align:center">
                                            <td colspan="3">
                                                <h2 style="font-size:60px; margin:0PX;text-transform:uppercase;font-family: cursive;">Mohan Educare</h2>
                                                <p style="margin:0PX;text-transform:uppercase">17/31, MOHAN BHAWAN, MOHALLA VIDYA RATTAN SOOD ST. NO.2, MOGA</p>
                                                <p style="margin:0PX;">Ph: 01636-224729</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="auto-style5">No. :</td>
                                                        <td class="auto-style2">1526</td>
                                                        <td class="auto-style3">&nbsp;</td>
                                                        <td class="auto-style4">Dated</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td class="auto-style1" colspan="5"><section style="  margin-top: 20px !important;  float: left;width: 100%;margin: 5px 0px;"><p style="font-size:19px; margin:0px; float:left">Received with thanks from : </p>  <p style="border-bottom:2px dotted black;float:left;width:450px; margin:0px;font-size:19px; height:24PX"> Gagandeep Singh</p> </section> </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" colspan="5"><section style="    float: left;width: 100%;margin: 5px 0px;"> <p style="font-size:19px; margin:0px; float:left">the sum of Rupees : &nbsp</p>  <p style="border-bottom:2px dotted black;float:left;width:450px ;font-size:19px; margin:0px;height:24PX"> Four Thousand Five Hundered Only</p> </section> </td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td class="auto-style1" colspan="5"><section style="    float: left;width: 100%;margin: 5px 0px;border-bottom:2px dotted black;    height: 23px;"> </section> </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="auto-style1" colspan="5"><section style="    float: left;width: 100%;margin: 5px 0px;"> <p style="font-size:19px; margin:0px; float:left">by Cash/Cheque/Draft No. : &nbsp</p>  <p style="border-bottom:2px dotted black;float:left;width:327px ;font-size:19px; margin:0px; height:24PX"> Four Thousand Five Hundered Only </p> <span style="font-size:19px">Dt</span>  <p style="border-bottom:2px dotted black;float:right;width:131px ;font-size:19px; margin:0px;height:24PX"></p> </section> </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style1" colspan="5"><section style="    float: left;width: 100%;margin: 5px 0px;"><p style="font-size:19px; margin:0px; float:left">on account of : </p>  <p style="border-bottom:2px dotted black;float:left;width:450px; margin:0px;font-size:19px; height:24PX"> </p> </section> </td>
                                                    </tr>
                                                    <tr>
                                                        
                                                        <td class="auto-style1" colspan="5"><section style="    float: left;width: 100%;margin: 20px 0px;"><p style="font-size:19px; margin:0px; float:left">Rs. </p>  <p style="float:left;width:450px; margin:0px;font-size:19px; height:24PX"> </p> <p style="float:right;width:131px ;font-size:19px; margin:0px;height:24PX">Signature</p>  </section> </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
    </form>
</body>
</html>
