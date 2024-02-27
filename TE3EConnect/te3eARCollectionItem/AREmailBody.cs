using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eARCollectionItem
{
    public static class AREmailBody
    {
        public static string EmailBodyHtml =
            @"
<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:w=""urn:schemas-microsoft-com:office:word"" xmlns:m=""http://schemas.microsoft.com/office/2004/12/omml"" xmlns=""http://www.w3.org/TR/REC-html40"">
   <head>
      <META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=us-ascii"">
      <meta name=Generator content=""Microsoft Word 15 (filtered medium)"">
      <style>
         <!--
            /* Font Definitions */
            @font-face
            	{font-family:""Cambria Math"";
            	panose-1:2 4 5 3 5 4 6 3 2 4;}
    @font-face
            	{font-family:Calibri;
            	panose-1:2 15 5 2 2 2 4 3 2 4;}
/* Style Definitions */
p.MsoNormal, li.MsoNormal, div.MsoNormal
            	{margin:0in;
            	margin-bottom:.0001pt;
            	font-size:11.0pt;
            	font-family:""Calibri"",sans-serif;}
            a:link, span.MsoHyperlink
            	{mso-style-priority:99;
            	color:#0563C1;
            	text-decoration:underline;}
            a:visited, span.MsoHyperlinkFollowed
            	{mso-style-priority:99;
            	color:#954F72;
            	text-decoration:underline;}
            p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph
            	{mso-style-priority:34;
            	margin-top:0in;
            	margin-right:0in;
            	margin-bottom:0in;
            	margin-left:.5in;
            	margin-bottom:.0001pt;
            	font-size:11.0pt;
            	font-family:""Calibri"",sans-serif;}
            span.EmailStyle17
            	{mso-style-type:personal-compose;
            	font-family:""Calibri"",sans-serif;
            	color:windowtext;}
            .MsoChpDefault
            	{mso-style-type:export-only;
            	font-family:""Calibri"",sans-serif;}
            @page WordSection1
{
    size:8.5in 11.0in;
    margin:1.0in 1.0in 1.0in 1.0in;
}
div.WordSection1
            	{page:WordSection1;}

#container {
            width: 100%;
        }

        #left {
            float: left;
            width: 50%;
            height: auto;
        }


        #right {
            float: right;
            width: 50%;
            height: auto;
        }
            -->
      </style>
      <!--[if gte mso 9]>
      <xml>
         <o:shapedefaults v:ext=""edit"" spidmax=""1026"" />
      </xml>
      <![endif]--><!--[if gte mso 9]>
      <xml>
         <o:shapelayout v:ext=""edit"">
            <o:idmap v:ext=""edit"" data=""1"" />
         </o:shapelayout>
      </xml>
      <![endif]-->
   </head>
   <body lang=EN - US link=""#0563C1"" vlink=""#954F72"">
    <p class=MsoNormal>
        <o:p>&nbsp;</o:p>
    </p>
    <p class=MsoNormal>
        <o:p>&nbsp;</o:p>
    </p>
      @letterHead
      <div class=WordSection1>
         @emailToParagraph
        <p class=MsoNormal>
            <o:p>&nbsp;</o:p>
        </p>
        
        <p class=MsoNormal style='text-indent:.5in'>
            Dear Valued Client,
            <o:p></o:p>
        </p>

         <p class=MsoNormal>
            <o:p>&nbsp;</o:p>
         </p>
         <p class=MsoListParagraph>
            Our records indicate that there is an outstanding balance on this matter.  Please visit this email attachment for details.
            <o:p></o:p>
         </p>
         <p class=MsoListParagraph>
            <o:p>&nbsp;</o:p>
         </p>
       
         <p class=MsoNormal style='margin-left:.5in' >
            Sincerely,
            <o:p></o:p>
         </p>
         <p class=MsoNormal style='margin-left:.5in' >
            Rimkus Consulting Group, Inc.
            <o:p></o:p>
         </p>
         <p class=MsoNormal>
            <o:p>&nbsp;</o:p>
         </p>
         <p class=MsoNormal>
            <o:p>&nbsp;</o:p>
         </p>
        <p class=MsoNormal style='margin-left:.5in'><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
          style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
          Arial'>This email and any files transmitted with it are confidential and intended solely for the use of the individual or 
entity to whom they are addressed. If you have received this email in error, please notify the system manager. This message contains confidential
information and is intended only for the individual named. If you are not the named addressee you should not disseminate, distribute or copy this e-mail.<o:p></o:p></span></i>
				        </span>
			</p>
         <p class=MsoNormal>
            <o:p>&nbsp;</o:p>
         </p>
      </div>
   </body>
</html>

";
        public static string BankingInfo = @"<p class=MsoNormal align=center style='text-align:center'><i style='mso-bidi-font-style:
normal'>Please include Claim and Invoice number on remittance. Thank you for
your business.</i><o:p></o:p></p>

<p class=MsoNormal><o:p>&nbsp;</o:p></p>

<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 style='border-collapse:collapse;mso-yfti-tbllook:1184;mso-padding-alt:0in 5.4pt 0in 5.4pt'>
	<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes'>
		<td width=109 valign=top style='width:81.9pt;padding:0in 5.4pt 0in 5.4pt'>
			<p class=MsoNormal><a name='REMIT_INSTRUCTIONS'><b style='mso-bidi-font-weight:
  normal'><span style='font-size:10.0pt;mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></b></a></p> <span style='mso-bookmark:REMIT_INSTRUCTIONS'></span>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><b
  style='mso-bidi-font-weight:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'><o:p>&nbsp;</o:p></span></b>
				</span>
			</p>
		</td> <span style='mso-bookmark:REMIT_INSTRUCTIONS'></span>
		<td width=270 valign=top style='width:202.5pt;padding:0in 5.4pt 0in 5.4pt'>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><span
  style='font-size:10.0pt;mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><b
  style='mso-bidi-font-weight:normal'><i style='mso-bidi-font-style:normal'><span
  style='font-size:10.0pt;mso-bidi-font-family:Arial'>Mail To:<o:p></o:p></span></i>
				</b>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>Rimkus Consulting Group, Inc.<o:p></o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>P.O. Box 4673<o:p></o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>Houston, TX 77210<o:p></o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'><o:p>&nbsp;</o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>Federal ID: 76-0163936</span></i>
				</span><span style='mso-bookmark:
  REMIT_INSTRUCTIONS'><span style='font-size:10.0pt;mso-bidi-font-family:Arial'><o:p></o:p></span></span>
			</p>
		</td> <span style='mso-bookmark:REMIT_INSTRUCTIONS'></span>
		<td width=259 valign=top style='width:2.7in;padding:0in 5.4pt 0in 5.4pt'>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'><o:p>&nbsp;</o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><b
  style='mso-bidi-font-weight:normal'><i style='mso-bidi-font-style:normal'><span
  style='font-size:10.0pt;mso-bidi-font-family:Arial'>Wire Instructions:<o:p></o:p></span></i>
				</b>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>ABA Number: 113010547<o:p></o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>Swift Code: CPASUS44<o:p></o:p></span></i>
				</span>
			</p>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><i
  style='mso-bidi-font-style:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'>Account Number: 0038514385<o:p></o:p></span></i>
				</span>
			</p> <span style='mso-bookmark:REMIT_INSTRUCTIONS'></span>
			<p class=MsoNormal><span style='mso-bookmark:REMIT_INSTRUCTIONS'><b
  style='mso-bidi-font-weight:normal'><span style='font-size:10.0pt;mso-bidi-font-family:
  Arial'><o:p>&nbsp;</o:p></span></b>
				</span>
			</p>
		</td> <span style='mso-bookmark:REMIT_INSTRUCTIONS'></span> </tr>
</table>

<span style='mso-bookmark:REMIT_INSTRUCTIONS'></span>

<p class=MsoNormal><o:p>&nbsp;</o:p></p>";

        public static string LetterHead = @"<div id='container'>
        <div id='left' style='width:204px;height:74px; margin-left:.5in'>
            <img src='data:image/jpg;base64,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' id='p1img1'>
            <p class=MsoNormal>
                <o:p>&nbsp;</o:p>
            </p>
            <p class=MsoNormal>
                <o:p>@currentDate</o:p>
            </p>
            <p class=MsoNormal>
                <o:p>&nbsp;</o:p>
            </p>
            <p class=MsoNormal>
                <o:p>&nbsp;</o:p>
            </p>
        </div>
        <div id='#right' style='float: right; margin-right:.5in;'>
            <p class=MsoNormal>
                <b><o:p>@billingOrgName</o:p></b>
            </p>
            <p class=MsoNormal>
                <b><o:p>@billingStreet</o:p></b>
            </p>
            <p class=MsoNormal>
                <b><o:p>@billingCityState</o:p></b>
            </p>
            
            <p class=MsoNormal>
                <b><o:p>Telephone: (713) 621-3550</o:p></b>
            </p>
        </div>
    </div>
    <br/><br />";

        public static string SpaceHeader = @"<p class=MsoNormal>
            <o:p>&nbsp;</o:p>
        </p>
        <p class=MsoNormal>
            <o:p>&nbsp;</o:p>
        </p>
        <p class=MsoNormal>
            <o:p></o:p>
        </p>";

        public static string EmailToParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Client Email: @clientEmail
            <o:p></o:p>
         </p>";

        public static string DateOfLossParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Date of Loss: @dateOfLoss
            <o:p></o:p>
         </p>";

        public static string ReferenceParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Reference No.: @referenceNo
            <o:p></o:p>
         </p>";

        public static string InsuredParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Insured: @insuredName
            <o:p></o:p>
         </p>";

        public static string ClaimantParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Claimant Name: @claimant
            <o:p></o:p>
         </p>";

        public static string StyleParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Style: @styleName
            <o:p></o:p>
         </p>";

        public static string CauseParagraph = @"<p class=MsoNormal style = 'text-indent:.5in' >
            Cause No.: @causeNo
            <o:p></o:p>
         </p>";

        public static string ClaimParagraph = @"<p class=MsoNormal style='text-indent:.5in' >
            Claim No.: @claimNo
            <o:p></o:p>
         </p>";

        public static string ItemizedCollectionTable =
            @"<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 style='margin-left:110.9pt;border-collapse:collapse;border:none'>
            <tr>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <b>Invoice Date</b>
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign= top style= 'width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <b>Invoice Number</b>
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign= top style= 'width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <b>Billed Amount</b>
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign= top style= 'width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <b>Received</b>
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <b>Balance Due</b>
                     <o:p></o:p>
                  </p>
               </td>
            </tr>
            @itemizedRow
            <tr>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
            </tr>
            <tr>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     <o:p>&nbsp;</o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     <b>Total Amount Due</b>
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt'>
                  <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     <b>$@totalAmtDue</b>
                     <o:p></o:p>
                  </p>
               </td>
            </tr>
         </table>";

        public static string ItemizedRow =
            @"<tr>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     @invoiceDate
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=center style='margin-left:0in;text-align:center'>
                     @invoiceNumber
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     $@billedAmount
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     ($@received)
                     <o:p></o:p>
                  </p>
               </td>
               <td width=150 valign=top style='width:100.5pt;padding:0in 5.4pt 0in 5.4pt' >
  
                    <p class=MsoListParagraph align=right style='margin-left:0in;text-align:center'>
                     $@balanceDue
                     <o:p></o:p>
                  </p>
               </td>
            </tr>";
    }
}
