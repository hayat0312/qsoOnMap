﻿using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int clicktimes = 0;
        Dictionary<string, string> countryCode;
        Dictionary<string, (double?, double?)> countryLatlng;
        Dictionary<string, (double?, double?)> callsignLocation;
        string mapHtml = @"C:\Users\ouchi\source\repos\WindowsFormsApp1\WindowsFormsApp1\testMap.html";
        ChromiumWebBrowser cefBrowser;
        CefSettings settings;

        public Form1()
        {
            //this.WindowState = FormWindowState.Maximized;

            InitializeComponent();

            //mapButton.Enabled = false;
            toolStripStatusLabel.Text = "読み込み中...";

            settings = new CefSettings();
            // レンダリングを最適化(これをやらないとバグる)
            settings.SetOffScreenRenderingBestPerformanceArgs();
            Cef.Initialize(settings);
            cefBrowser = new ChromiumWebBrowser(mapHtml);
            cefBrowser.LoadingStateChanged += CefBrowser_LoadingStateChanged;
            // Panelに合わせて表示
            mapPanel.Controls.Add(cefBrowser);
            cefBrowser.Dock = DockStyle.Fill;

            ResisterCountry();
            InitializeAllList();
            InitializeCqList();
            InitializeDetailList();
        }

        private void CefBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                // 読み込み完了時
                Invoke((MethodInvoker)delegate
                {
                    toolStripStatusLabel.Text = "読み込み完了";
                    //mapButton.Enabled = true;
                });
            }
        }

        private void ResisterCountry()
        {
            countryCode = new Dictionary<string, string>()
            {
                {"HB3Y", "Liechtenstein"},
                {"3DA", "Swaziland"},
                {"3DB", "Swaziland"},
                {"3DC", "Swaziland"},
                {"3DD", "Swaziland"},
                {"3DE", "Swaziland"},
                {"3DF", "Swaziland"},
                {"3DG", "Swaziland"},
                {"3DH", "Swaziland"},
                {"3DI", "Swaziland"},
                {"3DJ", "Swaziland"},
                {"3DK", "Swaziland"},
                {"3DL", "Swaziland"},
                {"3DM", "Swaziland"},
                {"3DN", "Fiji"},
                {"3DO", "Fiji"},
                {"3DP", "Fiji"},
                {"3DQ", "Fiji"},
                {"3DR", "Fiji"},
                {"3DS", "Fiji"},
                {"3DT", "Fiji"},
                {"3DU", "Fiji"},
                {"3DV", "Fiji"},
                {"3DW", "Fiji"},
                {"3DX", "Fiji"},
                {"3DY", "Fiji"},
                {"3DZ", "Fiji"},
                {"9M0", "Spratly Islands"},
                {"BV9", "Spratly Islands"},
                {"DX0", "Spratly Islands"},
                {"HB0", "Liechtenstein"},
                {"HBL", "Liechtenstein"},
                {"RA6", "Chechnya"},
                {"SSA", "Egypt"},
                {"SSB", "Egypt"},
                {"SSC", "Egypt"},
                {"SSD", "Egypt"},
                {"SSE", "Egypt"},
                {"SSF", "Egypt"},
                {"SSG", "Egypt"},
                {"SSH", "Egypt"},
                {"SSI", "Egypt"},
                {"SSJ", "Egypt"},
                {"SSK", "Egypt"},
                {"SSL", "Egypt"},
                {"SSM", "Egypt"},
                {"0S", "Principality of Seborga"},
                {"1A", "Sovereign Military Order of Malta"},
                {"1B", "Northern Cyprus or Blenheim Reef"},
                {"1G", "Geyser Reef"},
                {"1L", "Liberland"},
                {"1M", "Minerva Reefs"},
                {"1S", "Principality of Sealand"},
                {"1Z", "Kayin State"},
                {"3A", "Monaco"},
                {"3B", "Mauritius"},
                {"3C", "Equatorial Guinea"},
                {"3E", "Panama"},
                {"3F", "Panama"},
                {"3G", "Chile"},
                {"3H", "People's Republic of China"},
                {"3I", "People's Republic of China"},
                {"3J", "People's Republic of China"},
                {"3K", "People's Republic of China"},
                {"3L", "People's Republic of China"},
                {"3M", "People's Republic of China"},
                {"3N", "People's Republic of China"},
                {"3O", "People's Republic of China"},
                {"3P", "People's Republic of China"},
                {"3Q", "People's Republic of China"},
                {"3R", "People's Republic of China"},
                {"3S", "People's Republic of China"},
                {"3T", "People's Republic of China"},
                {"3U", "People's Republic of China"},
                {"3V", "Tunisia"},
                {"3W", "Vietnam"},
                {"3X", "Guinea"},
                {"3Y", "Norway"},
                {"3Z", "Poland"},
                {"4A", "Mexico"},
                {"4B", "Mexico"},
                {"4C", "Mexico"},
                {"4D", "Philippines"},
                {"4E", "Philippines"},
                {"4F", "Philippines"},
                {"4G", "Philippines"},
                {"4H", "Philippines"},
                {"4I", "Philippines"},
                {"4J", "Azerbaijan"},
                {"4K", "Azerbaijan"},
                {"4L", "Georgia"},
                {"4M", "Venezuela"},
                {"4O", "Montenegro"},
                {"4P", "Sri Lanka"},
                {"4Q", "Sri Lanka"},
                {"4R", "Sri Lanka"},
                {"4S", "Sri Lanka"},
                {"4T", "Peru"},
                {"4U", "United Nations (non-geographical)"},
                {"4V", "Haiti"},
                {"4W", "East Timor"},
                {"4X", "Israel"},
                {"4Y", "International Civil Aviation Organization (non-geographical)"},
                {"4Z", "Israel"},
                {"5A", "Libya"},
                {"5B", "Cyprus"},
                {"5C", "Morocco"},
                {"5D", "Morocco"},
                {"5E", "Morocco"},
                {"5F", "Morocco"},
                {"5G", "Morocco"},
                {"5H", "Tanzania"},
                {"5I", "Tanzania"},
                {"5J", "Colombia"},
                {"5K", "Colombia"},
                {"5L", "Liberia"},
                {"5M", "Liberia"},
                {"5N", "Nigeria"},
                {"5O", "Nigeria"},
                {"5P", "Denmark"},
                {"5Q", "Denmark"},
                {"5R", "Madagascar"},
                {"5S", "Madagascar"},
                {"5T", "Mauritania"},
                {"5U", "Niger"},
                {"5V", "Togo"},
                {"5W", "Western Samoa"},
                {"5X", "Uganda"},
                {"5Y", "Kenya"},
                {"5Z", "Kenya"},
                {"6A", "Egypt"},
                {"6B", "Egypt"},
                {"6C", "Syria"},
                {"6D", "Mexico"},
                {"6E", "Mexico"},
                {"6F", "Mexico"},
                {"6G", "Mexico"},
                {"6H", "Mexico"},
                {"6I", "Mexico"},
                {"6J", "Mexico"},
                {"6K", "South Korea"},
                {"6L", "South Korea"},
                {"6M", "South Korea"},
                {"6N", "South Korea"},
                {"6O", "Somalia"},
                {"6P", "Pakistan"},
                {"6Q", "Pakistan"},
                {"6R", "Pakistan"},
                {"6S", "Pakistan"},
                {"6T", "Sudan"},
                {"6U", "Sudan"},
                {"6V", "Senegal"},
                {"6W", "Senegal"},
                {"6X", "Madagascar"},
                {"6Y", "Jamaica"},
                {"6Z", "Liberia"},
                {"7A", "Indonesia"},
                {"7B", "Indonesia"},
                {"7C", "Indonesia"},
                {"7D", "Indonesia"},
                {"7E", "Indonesia"},
                {"7F", "Indonesia"},
                {"7G", "Indonesia"},
                {"7H", "Indonesia"},
                {"7I", "Indonesia"},
                {"7J", "Japan"},
                {"7K", "Japan"},
                {"7L", "Japan"},
                {"7M", "Japan"},
                {"7N", "Japan"},
                {"7O", "Yemen"},
                {"7P", "Lesotho"},
                {"7Q", "Malawi"},
                {"7R", "Algeria"},
                {"7S", "Sweden"},
                {"7T", "Algeria"},
                {"7U", "Algeria"},
                {"7V", "Algeria"},
                {"7W", "Algeria"},
                {"7X", "Algeria"},
                {"7Y", "Algeria"},
                {"7Z", "Saudi Arabia"},
                {"8A", "Indonesia"},
                {"8B", "Indonesia"},
                {"8C", "Indonesia"},
                {"8D", "Indonesia"},
                {"8E", "Indonesia"},
                {"8F", "Indonesia"},
                {"8G", "Indonesia"},
                {"8H", "Indonesia"},
                {"8I", "Indonesia"},
                {"8J", "Japan"},
                {"8K", "Japan"},
                {"8L", "Japan"},
                {"8M", "Japan"},
                {"8N", "Japan"},
                {"8O", "Botswana"},
                {"8P", "Barbados"},
                {"8Q", "Maldives"},
                {"8R", "Guyana"},
                {"8S", "Sweden"},
                {"8T", "India"},
                {"8U", "India"},
                {"8V", "India"},
                {"8W", "India"},
                {"8X", "India"},
                {"8Y", "India"},
                {"8Z", "Saudi Arabia"},
                {"9A", "Croatia"},
                {"9B", "Iran"},
                {"9C", "Iran"},
                {"9D", "Iran"},
                {"9E", "Ethiopia"},
                {"9F", "Ethiopia"},
                {"9G", "Ghana"},
                {"9H", "Malta"},
                {"9I", "Zambia"},
                {"9J", "Zambia"},
                {"9K", "Kuwait"},
                {"9L", "Sierra Leone"},
                {"9M", "Malaysia"},
                {"9N", "Nepal"},
                {"9O", "Democratic Republic of the Congo"},
                {"9P", "Democratic Republic of the Congo"},
                {"9Q", "Democratic Republic of the Congo"},
                {"9R", "Democratic Republic of the Congo"},
                {"9S", "Democratic Republic of the Congo"},
                {"9T", "Democratic Republic of the Congo"},
                {"9U", "Burundi"},
                {"9V", "Singapore"},
                {"9W", "Malaysia"},
                {"9X", "Rwanda"},
                {"9Y", "Trinidad and Tobago"},
                {"9Z", "Trinidad and Tobago"},
                {"A2", "Botswana"},
                {"A3", "Tonga"},
                {"A4", "Oman"},
                {"A5", "Bhutan"},
                {"A6", "United Arab Emirates"},
                {"A7", "Qatar"},
                {"A8", "Liberia"},
                {"A9", "Bahrain"},
                {"AA", "United States"},
                {"AB", "United States"},
                {"AC", "United States"},
                {"AD", "United States"},
                {"AE", "United States"},
                {"AF", "United States"},
                {"AG", "United States"},
                {"AH", "United States"},
                {"AI", "United States"},
                {"AJ", "United States"},
                {"AK", "United States"},
                {"AL", "United States"},
                {"AM", "Spain"},
                {"AN", "Spain"},
                {"AO", "Spain"},
                {"AP", "Pakistan"},
                {"AQ", "Pakistan"},
                {"AR", "Pakistan"},
                {"AS", "Pakistan"},
                {"AT", "India"},
                {"AU", "India"},
                {"AV", "India"},
                {"AW", "India"},
                {"AX", "Australia"},
                {"AY", "Argentina"},
                {"AZ", "Argentina"},
                {"BM", "Taiwan"},
                {"BN", "Taiwan"},
                {"BO", "Taiwan"},
                {"BP", "Taiwan"},
                {"BQ", "Taiwan"},
                {"BU", "Taiwan"},
                {"BV", "Taiwan"},
                {"BW", "Taiwan"},
                {"BX", "Taiwan"},
                {"C2", "Nauru"},
                {"C3", "Andorra"},
                {"C4", "Cyprus"},
                {"C5", "The Gambia"},
                {"C6", "Bahamas"},
                {"C7", "World Meteorological Organization (non-geographical)"},
                {"C8", "Mozambique"},
                {"C9", "Mozambique"},
                {"CA", "Chile"},
                {"CB", "Chile"},
                {"CC", "Chile"},
                {"CD", "Chile"},
                {"CE", "Chile"},
                {"CF", "Canada"},
                {"CG", "Canada"},
                {"CH", "Canada"},
                {"CI", "Canada"},
                {"CJ", "Canada"},
                {"CK", "Canada"},
                {"CL", "Cuba"},
                {"CM", "Cuba"},
                {"CN", "Morocco"},
                {"CO", "Cuba"},
                {"CP", "Bolivia"},
                {"CQ", "Portugal"},
                {"CR", "Portugal"},
                {"CS", "Portugal"},
                {"CT", "Portugal"},
                {"CU", "Portugal"},
                {"CV", "Uruguay"},
                {"CW", "Uruguay"},
                {"CX", "Uruguay"},
                {"CY", "Canada"},
                {"CZ", "Canada"},
                {"D0", "Donetsk"},
                {"D1", "Donetsk"},
                {"D2", "Angola"},
                {"D3", "Angola"},
                {"D4", "Cape Verde"},
                {"D5", "Liberia"},
                {"D6", "Comoros"},
                {"D7", "South Korea"},
                {"D8", "South Korea"},
                {"D9", "South Korea"},
                {"DA", "Germany"},
                {"DB", "Germany"},
                {"DC", "Germany"},
                {"DD", "Germany"},
                {"DE", "Germany"},
                {"DF", "Germany"},
                {"DG", "Germany"},
                {"DH", "Germany"},
                {"DI", "Germany"},
                {"DJ", "Germany"},
                {"DK", "Germany"},
                {"DL", "Germany"},
                {"DM", "Germany"},
                {"DN", "Germany"},
                {"DO", "Germany"},
                {"DP", "Germany"},
                {"DQ", "Germany"},
                {"DR", "Germany"},
                {"DS", "South Korea"},
                {"DT", "South Korea"},
                {"DU", "Philippines"},
                {"DV", "Philippines"},
                {"DW", "Philippines"},
                {"DX", "Philippines"},
                {"DY", "Philippines"},
                {"DZ", "Philippines"},
                {"E2", "Thailand"},
                {"E3", "Eritrea"},
                {"E4", "Palestine"},
                {"E5", "Cook Islands"},
                {"E6", "Niue"},
                {"E7", "Bosnia and Herzegovina"},
                {"EA", "Spain"},
                {"EB", "Spain"},
                {"EC", "Spain"},
                {"ED", "Spain"},
                {"EE", "Spain"},
                {"EF", "Spain"},
                {"EG", "Spain"},
                {"EH", "Spain"},
                {"EI", "Ireland"},
                {"EJ", "Ireland"},
                {"EK", "Armenia"},
                {"EL", "Liberia"},
                {"EM", "Ukraine"},
                {"EN", "Ukraine"},
                {"EO", "Ukraine"},
                {"EP", "Iran"},
                {"EQ", "Iran"},
                {"ER", "Moldova"},
                {"ES", "Estonia"},
                {"ET", "Ethiopia"},
                {"EU", "Belarus"},
                {"EV", "Belarus"},
                {"EW", "Belarus"},
                {"EX", "Kyrgyzstan"},
                {"EY", "Tajikistan"},
                {"EZ", "Turkmenistan"},
                {"H2", "Cyprus"},
                {"H3", "Panama"},
                {"H4", "Solomon Islands"},
                {"H5", "Bophuthatswana"},
                {"H6", "Nicaragua"},
                {"H7", "Nicaragua"},
                {"H8", "Panama"},
                {"H9", "Panama"},
                {"HA", "Hungary"},
                {"HB", "Switzerland"},
                {"HC", "Ecuador"},
                {"HD", "Ecuador"},
                {"HE", "Switzerland"},
                {"HF", "Poland"},
                {"HG", "Hungary"},
                {"HH", "Haiti"},
                {"HI", "Dominican Republic"},
                {"HJ", "Colombia"},
                {"HK", "Colombia"},
                {"HL", "South Korea"},
                {"HM", "North Korea"},
                {"HN", "Iraq"},
                {"HO", "Panama"},
                {"HP", "Panama"},
                {"HQ", "Honduras"},
                {"HR", "Honduras"},
                {"HS", "Thailand"},
                {"HT", "Nicaragua"},
                {"HU", "El Salvador"},
                {"HV", "Vatican City"},
                {"HW", "France / overseas departments / territories"},
                {"HX", "France / overseas departments / territories"},
                {"HY", "France / overseas departments / territories"},
                {"HZ", "Saudi Arabia"},
                {"J2", "Djibouti"},
                {"J3", "Grenada"},
                {"J4", "Greece"},
                {"J5", "Guinea-Bissau"},
                {"J6", "Saint Lucia"},
                {"J7", "Dominica"},
                {"J8", "Saint Vincent and the Grenadines"},
                {"JA", "Japan"},
                {"JB", "Japan"},
                {"JC", "Japan"},
                {"JD", "Japan"},
                {"JE", "Japan"},
                {"JF", "Japan"},
                {"JG", "Japan"},
                {"JH", "Japan"},
                {"JI", "Japan"},
                {"JJ", "Japan"},
                {"JK", "Japan"},
                {"JL", "Japan"},
                {"JM", "Japan"},
                {"JN", "Japan"},
                {"JO", "Japan"},
                {"JP", "Japan"},
                {"JQ", "Japan"},
                {"JR", "Japan"},
                {"JS", "Japan"},
                {"JT", "Mongolia"},
                {"JU", "Mongolia"},
                {"JV", "Mongolia"},
                {"JW", "Norway"},
                {"JX", "Norway"},
                {"JY", "Jordan"},
                {"JZ", "Indonesia"},
                {"L2", "Argentina"},
                {"L3", "Argentina"},
                {"L4", "Argentina"},
                {"L5", "Argentina"},
                {"L6", "Argentina"},
                {"L7", "Argentina"},
                {"L8", "Argentina"},
                {"L9", "Argentina"},
                {"LA", "Norway"},
                {"LB", "Norway"},
                {"LC", "Norway"},
                {"LD", "Norway"},
                {"LE", "Norway"},
                {"LF", "Norway"},
                {"LG", "Norway"},
                {"LH", "Norway"},
                {"LI", "Norway"},
                {"LJ", "Norway"},
                {"LK", "Norway"},
                {"LL", "Norway"},
                {"LM", "Norway"},
                {"LN", "Norway"},
                {"LO", "Argentina"},
                {"LP", "Argentina"},
                {"LQ", "Argentina"},
                {"LR", "Argentina"},
                {"LS", "Argentina"},
                {"LT", "Argentina"},
                {"LU", "Argentina"},
                {"LV", "Argentina"},
                {"LW", "Argentina"},
                {"LX", "Luxembourg"},
                {"LY", "Lithuania"},
                {"LZ", "Bulgaria"},
                {"O1", "South Ossetia"},
                {"OA", "Peru"},
                {"OB", "Peru"},
                {"OC", "Peru"},
                {"OD", "Lebanon"},
                {"OE", "Austria"},
                {"OF", "Finland"},
                {"OG", "Finland"},
                {"OH", "Finland"},
                {"OI", "Finland"},
                {"OJ", "Finland"},
                {"OK", "Czech Republic"},
                {"OL", "Czech Republic"},
                {"OM", "Slovakia"},
                {"ON", "Belgium"},
                {"OO", "Belgium"},
                {"OP", "Belgium"},
                {"OQ", "Belgium"},
                {"OR", "Belgium"},
                {"OS", "Belgium"},
                {"OT", "Belgium"},
                {"OU", "Denmark"},
                {"OV", "Denmark"},
                {"OW", "Denmark"},
                {"OX", "Denmark"},
                {"OY", "Denmark"},
                {"OZ", "Denmark"},
                {"P2", "Papua New Guinea"},
                {"P3", "Cyprus"},
                {"P4", "Aruba"},
                {"P5", "North Korea"},
                {"P6", "North Korea"},
                {"P7", "North Korea"},
                {"P8", "North Korea"},
                {"P9", "North Korea"},
                {"PA", "Netherlands"},
                {"PB", "Netherlands"},
                {"PC", "Netherlands"},
                {"PD", "Netherlands"},
                {"PE", "Netherlands"},
                {"PF", "Netherlands"},
                {"PG", "Netherlands"},
                {"PH", "Netherlands"},
                {"PI", "Netherlands"},
                {"PJ", "Netherlands - former Netherlands Antilles"},
                {"PK", "Indonesia"},
                {"PL", "Indonesia"},
                {"PM", "Indonesia"},
                {"PN", "Indonesia"},
                {"PO", "Indonesia"},
                {"PP", "Brazil"},
                {"PQ", "Brazil"},
                {"PR", "Brazil"},
                {"PS", "Brazil"},
                {"PT", "Brazil"},
                {"PU", "Brazil"},
                {"PV", "Brazil"},
                {"PW", "Brazil"},
                {"PX", "Brazil"},
                {"PY", "Brazil"},
                {"PZ", "Suriname"},
                {"S0", "Western Sahara"},
                {"S2", "Bangladesh"},
                {"S3", "Bangladesh"},
                {"S5", "Slovenia"},
                {"S6", "Singapore"},
                {"S7", "Seychelles"},
                {"S8", "South Africa"},
                {"S9", "São Tomé and Príncipe"},
                {"SA", "Sweden"},
                {"SB", "Sweden"},
                {"SC", "Sweden"},
                {"SD", "Sweden"},
                {"SE", "Sweden"},
                {"SF", "Sweden"},
                {"SG", "Sweden"},
                {"SH", "Sweden"},
                {"SI", "Sweden"},
                {"SJ", "Sweden"},
                {"SK", "Sweden"},
                {"SL", "Sweden"},
                {"SM", "Sweden"},
                {"SN", "Poland"},
                {"SO", "Poland"},
                {"SP", "Poland"},
                {"SQ", "Poland"},
                {"SR", "Poland"},
                {"SS", "Sudan"},
                {"ST", "Sudan"},
                {"SU", "Egypt"},
                {"SV", "Greece"},
                {"SW", "Greece"},
                {"SX", "Greece"},
                {"SY", "Greece"},
                {"SZ", "Greece"},
                {"T0", "Principality of Seborga"},
                {"T1", "Transnistria"},
                {"T2", "Tuvalu"},
                {"T3", "Kiribati"},
                {"T4", "Cuba"},
                {"T5", "Somalia"},
                {"T6", "Afghanistan"},
                {"T7", "San Marino"},
                {"T8", "Palau"},
                {"TA", "Turkey"},
                {"TB", "Turkey"},
                {"TC", "Turkey"},
                {"TD", "Guatemala"},
                {"TE", "Costa Rica"},
                {"TF", "Iceland"},
                {"TG", "Guatemala"},
                {"TH", "France / overseas departments / territories"},
                {"TI", "Costa Rica"},
                {"TJ", "Cameroon"},
                {"TK", "France / overseas departments / territories"},
                {"TL", "Central African Republic"},
                {"TM", "France / overseas departments / territories"},
                {"TN", "Congo"},
                {"TO", "France / overseas departments / territories"},
                {"TP", "France / overseas departments / territories"},
                {"TQ", "France / overseas departments / territories"},
                {"TR", "Gabon"},
                {"TS", "Tunisia"},
                {"TT", "Chad"},
                {"TU", "Ivory Coast"},
                {"TV", "France / overseas departments / territories"},
                {"TW", "France / overseas departments / territories"},
                {"TX", "France / overseas departments / territories"},
                {"TY", "Benin"},
                {"TZ", "Mali"},
                {"UA", "Russia"},
                {"UB", "Russia"},
                {"UC", "Russia"},
                {"UD", "Russia"},
                {"UE", "Russia"},
                {"UF", "Russia"},
                {"UG", "Russia"},
                {"UH", "Russia"},
                {"UI", "Russia"},
                {"UJ", "Uzbekistan"},
                {"UK", "Uzbekistan"},
                {"UL", "Uzbekistan"},
                {"UM", "Uzbekistan"},
                {"UN", "Kazakhstan"},
                {"UO", "Kazakhstan"},
                {"UP", "Kazakhstan"},
                {"UQ", "Kazakhstan"},
                {"UR", "Ukraine"},
                {"US", "Ukraine"},
                {"UT", "Ukraine"},
                {"UU", "Ukraine"},
                {"UV", "Ukraine"},
                {"UW", "Ukraine"},
                {"UX", "Ukraine"},
                {"UY", "Ukraine"},
                {"UZ", "Ukraine"},
                {"V2", "Antigua and Barbuda"},
                {"V3", "Belize"},
                {"V4", "Saint Kitts and Nevis"},
                {"V5", "Namibia"},
                {"V6", "Federated States of Micronesia"},
                {"V7", "Marshall Islands"},
                {"V8", "Brunei"},
                {"VA", "Canada"},
                {"VB", "Canada"},
                {"VC", "Canada"},
                {"VD", "Canada"},
                {"VE", "Canada"},
                {"VF", "Canada"},
                {"VG", "Canada"},
                {"VH", "Australia"},
                {"VI", "Australia"},
                {"VJ", "Australia"},
                {"VK", "Australia"},
                {"VL", "Australia"},
                {"VM", "Australia"},
                {"VN", "Australia"},
                {"VO", "Canada (Newfoundland)"},
                {"VP", "United Kingdom / overseas territories / dependencies"},
                {"VQ", "United Kingdom / overseas territories / dependencies"},
                {"VR", "Hong Kong"},
                {"VS", "United Kingdom"},
                {"VT", "India"},
                {"VU", "India"},
                {"VV", "India"},
                {"VW", "India"},
                {"VX", "Canada"},
                {"VY", "Canada"},
                {"VZ", "Australia"},
                {"XA", "Mexico"},
                {"XB", "Mexico"},
                {"XC", "Mexico"},
                {"XD", "Mexico"},
                {"XE", "Mexico"},
                {"XF", "Mexico"},
                {"XG", "Mexico"},
                {"XH", "Mexico"},
                {"XI", "Mexico"},
                {"XJ", "Canada"},
                {"XK", "Canada"},
                {"XL", "Canada"},
                {"XM", "Canada"},
                {"XN", "Canada"},
                {"XO", "Canada"},
                {"XP", "Denmark"},
                {"XQ", "Chile"},
                {"XR", "Chile"},
                {"XS", "People's Republic of China"},
                {"XT", "Burkina Faso"},
                {"XU", "Cambodia"},
                {"XV", "Vietnam"},
                {"XW", "Laos"},
                {"XX", "Macao"},
                {"XY", "Burma"},
                {"XZ", "Burma"},
                {"Y2", "Germany"},
                {"Y3", "Germany"},
                {"Y4", "Germany"},
                {"Y5", "Germany"},
                {"Y6", "Germany"},
                {"Y7", "Germany"},
                {"Y8", "Germany"},
                {"Y9", "Germany"},
                {"YA", "Afghanistan"},
                {"YB", "Indonesia"},
                {"YC", "Indonesia"},
                {"YD", "Indonesia"},
                {"YE", "Indonesia"},
                {"YF", "Indonesia"},
                {"YG", "Indonesia"},
                {"YH", "Indonesia"},
                {"YI", "Iraq"},
                {"YJ", "Vanuatu"},
                {"YK", "Syria"},
                {"YL", "Latvia"},
                {"YM", "Turkey"},
                {"YN", "Nicaragua"},
                {"YO", "Romania"},
                {"YP", "Romania"},
                {"YQ", "Romania"},
                {"YR", "Romania"},
                {"YS", "El Salvador"},
                {"YT", "Serbia"},
                {"YU", "Serbia"},
                {"YV", "Venezuela"},
                {"YW", "Venezuela"},
                {"YX", "Venezuela"},
                {"YY", "Venezuela"},
                {"Z2", "Zimbabwe"},
                {"Z3", "Republic of Macedonia"},
                {"Z6", "Kosovo"},
                {"Z8", "South Sudan"},
                {"ZA", "Albania"},
                {"ZB", "United Kingdom / overseas territories / dependencies"},
                {"ZC", "United Kingdom / overseas territories / dependencies"},
                {"ZD", "United Kingdom / overseas territories / dependencies"},
                {"ZE", "United Kingdom / overseas territories / dependencies"},
                {"ZF", "United Kingdom / overseas territories / dependencies"},
                {"ZG", "United Kingdom / overseas territories / dependencies"},
                {"ZH", "United Kingdom / overseas territories / dependencies"},
                {"ZI", "United Kingdom / overseas territories / dependencies"},
                {"ZJ", "United Kingdom / overseas territories / dependencies"},
                {"ZK", "New Zealand"},
                {"ZL", "New Zealand"},
                {"ZM", "New Zealand"},
                {"ZN", "United Kingdom / overseas territories / dependencies"},
                {"ZO", "United Kingdom / overseas territories / dependencies"},
                {"ZP", "Paraguay"},
                {"ZQ", "United Kingdom / overseas territories / dependencies"},
                {"ZR", "South Africa"},
                {"ZS", "South Africa"},
                {"ZT", "South Africa"},
                {"ZU", "South Africa"},
                {"ZV", "Brazil"},
                {"ZW", "Brazil"},
                {"ZX", "Brazil"},
                {"ZY", "Brazil"},
                {"ZZ", "Brazil"},
                {"2", "United Kingdom / overseas territories / dependencies"},
                {"B", "People's Republic of China"},
                {"F", "France / overseas departments / territories"},
                {"G", "United Kingdom / overseas territories / dependencies"},
                {"I", "Italy"},
                {"K", "United States"},
                {"M", "United Kingdom / overseas territories / dependencies"},
                {"N", "United States"},
                {"R", "Russia"},
                {"W", "United States"},
            };
            countryLatlng = new Dictionary<string, (double?, double?)>()
            {
                {"All", (null, null) },
                {"Liechtenstein", (47.166, 9.555373)},
                {"Swaziland", (-26.522503, 31.465866)},
                {"Fiji", (-17.713371, 178.065032)},
                {"Spratly Islands", (10.723282, 115.8264655)},
                {"Chechnya", (43.4023301, 45.7187468)},
                {"Egypt", (26.820553, 30.802498)},
                {"Principality of Seborga", (43.8317178, 7.7036561)},
                {"Sovereign Military Order of Malta", (41.905278, 12.480556)},
                {"Northern Cyprus or Blenheim Reef", (-5.2, 72.466667)},
                {"Geyser Reef", (-12.32, 46.45)},
                {"Liberland", (45.769578, 18.873631)},
                {"Minerva Reefs", (-23.8333333, -179)},
                {"Principality of Sealand", (51.895167, 1.4805)},
                {"Kayin State", (16.9459346, 97.9592863)},
                {"Monaco", (43.7384176, 7.4246158)},
                {"Mauritius", (-20.348404, 57.552152)},
                {"Equatorial Guinea", (1.650801, 10.267895)},
                {"Panama", (8.537981, -80.782127)},
                {"Chile", (-35.675147, -71.542969)},
                {"People's Republic of China", (35.86166, 104.195397)},
                {"Tunisia", (33.886917, 9.537499)},
                {"Vietnam", (14.058324, 108.277199)},
                {"Guinea", (9.945587, -9.696645)},
                {"Norway", (60.472024, 8.468946)},
                {"Poland", (51.919438, 19.145136)},
                {"Mexico", (23.634501, -102.552784)},
                {"Philippines", (12.879721, 121.774017)},
                {"Azerbaijan", (40.143105, 47.576927)},
                {"Georgia", (32.1656221, -82.9000751)},
                {"Venezuela", (6.42375, -66.58973)},
                {"Montenegro", (42.708678, 19.37439)},
                {"Sri Lanka", (7.873054, 80.771797)},
                {"Peru", (-9.189967, -75.015152)},
                {"Haiti", (18.971187, -72.285215)},
                {"East Timor", (-8.874217, 125.727539)},
                {"Israel", (31.046051, 34.851612)},
                {"Libya", (26.3351, 17.228331)},
                {"Cyprus", (35.126413, 33.429859)},
                {"Morocco", (31.791702, -7.09262)},
                {"Tanzania", (-6.369028, 34.888822)},
                {"Colombia", (4.570868, -74.297333)},
                {"Liberia", (6.428055, -9.429499)},
                {"Nigeria", (9.081999, 8.675277)},
                {"Denmark", (56.26392, 9.501785)},
                {"Madagascar", (-18.766947, 46.869107)},
                {"Mauritania", (21.00789, -10.940835)},
                {"Niger", (17.607789, 8.081666)},
                {"Togo", (8.619543, 0.824782)},
                {"Western Samoa", (-13.759029, -172.104629)},
                {"Uganda", (1.373333, 32.290275)},
                {"Kenya", (-0.023559, 37.906193)},
                {"Syria", (34.802075, 38.996815)},
                {"South Korea", (35.907757, 127.766922)},
                {"Somalia", (5.152149, 46.199616)},
                {"Pakistan", (30.375321, 69.345116)},
                {"Sudan", (12.862807, 30.217636)},
                {"Senegal", (14.497401, -14.452362)},
                {"Jamaica", (18.109581, -77.297508)},
                {"Indonesia", (-0.789275, 113.921327)},
                {"Japan", (36.204824, 138.252924)},
                {"Yemen", (15.552727, 48.516388)},
                {"Lesotho", (-29.609988, 28.233608)},
                {"Malawi", (-13.254308, 34.301525)},
                {"Algeria", (28.033886, 1.659626)},
                {"Sweden", (60.128161, 18.643501)},
                {"Saudi Arabia", (23.885942, 45.079162)},
                {"Botswana", (-22.328474, 24.684866)},
                {"Barbados", (13.193887, -59.543198)},
                {"Maldives", (3.202778, 73.22068)},
                {"Guyana", (4.860416, -58.93018)},
                {"India", (20.593684, 78.96288)},
                {"Croatia", (45.1, 15.2)},
                {"Iran", (32.427908, 53.688046)},
                {"Ethiopia", (9.145, 40.489673)},
                {"Ghana", (7.946527, -1.023194)},
                {"Malta", (35.937496, 14.375416)},
                {"Zambia", (-13.133897, 27.849332)},
                {"Kuwait", (29.31166, 47.481766)},
                {"Sierra Leone", (8.460555, -11.779889)},
                {"Malaysia", (4.210484, 101.975766)},
                {"Nepal", (28.394857, 84.124008)},
                {"Democratic Republic of the Congo", (-4.038333, 21.758664)},
                {"Burundi", (-3.373056, 29.918886)},
                {"Singapore", (1.352083, 103.819836)},
                {"Rwanda", (-1.940278, 29.873888)},
                {"Trinidad and Tobago", (10.691803, -61.222503)},
                {"Tonga", (-21.178986, -175.198242)},
                {"Oman", (21.4735329, 55.975413)},
                {"Bhutan", (27.514162, 90.433601)},
                {"United Arab Emirates", (23.424076, 53.847818)},
                {"Qatar", (25.354826, 51.183884)},
                {"Bahrain", (26.0667, 50.5577)},
                {"United States", (37.09024, -95.712891)},
                {"Spain", (40.463667, -3.74922)},
                {"Australia", (-25.274398, 133.775136)},
                {"Argentina", (-38.416097, -63.616672)},
                {"Taiwan", (23.69781, 120.960515)},
                {"Nauru", (-0.522778, 166.931503)},
                {"Andorra", (42.506285, 1.521801)},
                {"The Gambia", (13.443182, -15.310139)},
                {"Bahamas", (25.03428, -77.39628)},
                {"Mozambique", (-18.665695, 35.529562)},
                {"Canada", (56.130366, -106.346771)},
                {"Cuba", (21.521757, -77.781167)},
                {"Bolivia", (-16.290154, -63.588653)},
                {"Portugal", (39.399872, -8.224454)},
                {"Uruguay", (-32.522779, -55.765835)},
                {"Donetsk", (48.015883, 37.80285)},
                {"Angola", (-11.202692, 17.873887)},
                {"Cape Verde", (16.5388, -23.0418)},
                {"Comoros", (-11.6455, 43.3333)},
                {"Germany", (51.165691, 10.451526)},
                {"Thailand", (15.870032, 100.992541)},
                {"Eritrea", (15.179384, 39.782334)},
                {"Palestine", (31.952162, 35.233154)},
                {"Cook Islands", (-21.236736, -159.777671)},
                {"Niue", (-19.054445, -169.867233)},
                {"Bosnia and Herzegovina", (43.915886, 17.679076)},
                {"Ireland", (53.1423672, -7.6920536)},
                {"Armenia", (40.069099, 45.038189)},
                {"Ukraine", (48.379433, 31.16558)},
                {"Moldova", (47.411631, 28.369885)},
                {"Estonia", (58.595272, 25.013607)},
                {"Belarus", (53.709807, 27.953389)},
                {"Kyrgyzstan", (41.20438, 74.766098)},
                {"Tajikistan", (38.861034, 71.276093)},
                {"Turkmenistan", (38.969719, 59.556278)},
                {"Solomon Islands", (-9.64571, 160.156194)},
                {"Bophuthatswana", (-25.85, 25.633333)},
                {"Nicaragua", (12.865416, -85.207229)},
                {"Hungary", (47.162494, 19.503304)},
                {"Switzerland", (46.818188, 8.227512)},
                {"Ecuador", (-1.831239, -78.183406)},
                {"Dominican Republic", (18.735693, -70.162651)},
                {"North Korea", (40.339852, 127.510093)},
                {"Iraq", (33.223191, 43.679291)},
                {"Honduras", (15.199999, -86.241905)},
                {"El Salvador", (13.794185, -88.89653)},
                {"Vatican City", (41.902916, 12.453389)},
                {"France / overseas departments / territories", (46.227638, 2.213749)},
                {"Djibouti", (11.825138, 42.590275)},
                {"Grenada", (12.1165, -61.679)},
                {"Greece", (39.074208, 21.824312)},
                {"Guinea-Bissau", (11.803749, -15.180413)},
                {"Saint Lucia", (13.909444, -60.978893)},
                {"Dominica", (15.414999, -61.370976)},
                {"Saint Vincent and the Grenadines", (12.984305, -61.287228)},
                {"Mongolia", (46.862496, 103.846656)},
                {"Jordan", (30.585164, 36.238414)},
                {"Luxembourg", (49.815273, 6.129583)},
                {"Lithuania", (55.169438, 23.881275)},
                {"Bulgaria", (42.733883, 25.48583)},
                {"South Ossetia", (42.3842131, 44.0480845)},
                {"Lebanon", (33.854721, 35.862285)},
                {"Austria", (47.516231, 14.550072)},
                {"Finland", (61.92411, 25.748151)},
                {"Czech Republic", (49.817492, 15.472962)},
                {"Slovakia", (48.669026, 19.699024)},
                {"Belgium", (50.503887, 4.469936)},
                {"Papua New Guinea", (-6.314993, 143.95555)},
                {"Aruba", (12.52111, -69.968338)},
                {"Netherlands", (52.132633, 5.291266)},
                {"Netherlands - former Netherlands Antilles", (52.132633, 5.291266)},
                {"Brazil", (-14.235004, -51.92528)},
                {"Suriname", (3.919305, -56.027783)},
                {"Western Sahara", (24.215527, -12.885834)},
                {"Bangladesh", (23.684994, 90.356331)},
                {"Slovenia", (46.151241, 14.995463)},
                {"Seychelles", (-4.679574, 55.491977)},
                {"South Africa", (-30.559482, 22.937506)},
                {"São Tomé and Príncipe", (0.18636, 6.613081)},
                {"Transnistria", (47.2152972, 29.4638054)},
                {"Tuvalu", (-7.109535, 177.64933)},
                {"Kiribati", (-3.370417, -168.734039)},
                {"Afghanistan", (33.93911, 67.709953)},
                {"San Marino", (43.94236, 12.457777)},
                {"Palau", (7.51498, 134.58252)},
                {"Turkey", (38.963745, 35.243322)},
                {"Guatemala", (15.783471, -90.230759)},
                {"Costa Rica", (9.748917, -83.753428)},
                {"Iceland", (64.963051, -19.020835)},
                {"Cameroon", (7.369722, 12.354722)},
                {"Central African Republic", (6.611111, 20.939444)},
                {"Congo", (-4.038333, 21.758664)},
                {"Gabon", (-0.803689, 11.609444)},
                {"Chad", (15.454166, 18.732207)},
                {"Ivory Coast", (7.539989, -5.54708)},
                {"Benin", (9.30769, 2.315834)},
                {"Mali", (17.570692, -3.996166)},
                {"Russia", (61.52401, 105.318756)},
                {"Uzbekistan", (41.377491, 64.585262)},
                {"Kazakhstan", (48.019573, 66.923684)},
                {"Antigua and Barbuda", (17.060816, -61.796428)},
                {"Belize", (17.189877, -88.49765)},
                {"Saint Kitts and Nevis", (17.357822, -62.782998)},
                {"Namibia", (-22.95764, 18.49041)},
                {"Federated States of Micronesia", (7.425554, 150.550812)},
                {"Marshall Islands", (7.131474, 171.184478)},
                {"Brunei", (4.535277, 114.727669)},
                {"Canada (Newfoundland)", (53.1355091, -57.6604364)},
                {"Hong Kong", (22.3193039, 114.1693611)},
                {"United Kingdom", (55.378051, -3.435973)},
                {"Burkina Faso", (12.238333, -1.561593)},
                {"Cambodia", (12.565679, 104.990963)},
                {"Laos", (19.85627, 102.495496)},
                {"Macao", (22.198745, 113.543873)},
                {"Burma", (21.916221, 95.955974)},
                {"Vanuatu", (-15.376706, 166.959158)},
                {"Latvia", (56.879635, 24.603189)},
                {"Romania", (45.943161, 24.96676)},
                {"Serbia", (44.016521, 21.005859)},
                {"Zimbabwe", (-19.015438, 29.154857)},
                {"Republic of Macedonia", (41.608635, 21.745275)},
                {"Kosovo", (42.6026359, 20.902977)},
                {"South Sudan", (6.8769919, 31.3069788)},
                {"Albania", (41.153332, 20.168331)},
                {"New Zealand", (-40.900557, 174.885971)},
                {"Paraguay", (-23.442503, -58.443832)},
                {"Italy", (41.87194, 12.56738)}
            };
            callsignLocation = new Dictionary<string, (double?, double?)>()
            {

            };
        }

        private void InitializeAllList()
        {
            // ListViewコントロールのプロパティを設定
            allList.FullRowSelect = true;
            allList.GridLines = true;
            //listView1.Sorting = SortOrder.Ascending;
            allList.View = View.Details;

            // 列（コラム）ヘッダの作成
            ColumnHeader columnNumber = new ColumnHeader();
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            ColumnHeader columnData = new ColumnHeader();
            ColumnHeader columnDirection = new ColumnHeader();
            columnNumber.Text = "No.";
            columnNumber.Width = 30;
            columnName.Text = "時刻";
            columnName.Width = 110;
            columnType.Text = "周波数";
            columnType.Width = 60;
            columnData.Text = "メッセージ";
            columnData.Width = 150;
            columnDirection.Text = "向き";
            columnDirection.Width = 200;
            ColumnHeader[] colHeaderRegValue =
              {columnNumber, columnName, columnType, columnData, columnDirection};
            allList.Columns.AddRange(colHeaderRegValue);
        }

        private void InitializeCqList()
        {
            // ListViewコントロールのプロパティを設定
            cqList.FullRowSelect = true;
            cqList.GridLines = true;
            //listView1.Sorting = SortOrder.Ascending;
            cqList.View = View.Details;

            // 列（コラム）ヘッダの作成
            ColumnHeader columnNumber = new ColumnHeader();
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            ColumnHeader columnData = new ColumnHeader();
            ColumnHeader columnDirection = new ColumnHeader();

            columnNumber.Text = "No.";
            columnNumber.Width = 30;
            columnName.Text = "時刻";
            columnName.Width = 110;
            columnType.Text = "周波数";
            columnType.Width = 60;
            columnData.Text = "メッセージ";
            columnData.Width = 150;
            columnDirection.Text = "向き";
            columnDirection.Width = 200;
            ColumnHeader[] colHeaderRegValue =
              {columnNumber, columnName, columnType, columnData, columnDirection };
            cqList.Columns.AddRange(colHeaderRegValue);
        }

        private void InitializeDetailList()
        {
            // ListViewコントロールのプロパティを設定
            detailList.FullRowSelect = true;
            detailList.GridLines = true;
            //listView1.Sorting = SortOrder.Ascending;
            detailList.View = View.Details;

            // 列（コラム）ヘッダの作成
            ColumnHeader columnNumber = new ColumnHeader();
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            ColumnHeader columnData = new ColumnHeader();
            ColumnHeader columnDirection = new ColumnHeader();

            columnNumber.Text = "No.";
            columnNumber.Width = 30;
            columnName.Text = "時刻";
            columnName.Width = 110;
            columnType.Text = "タイプ";
            columnType.Width = 60;
            columnData.Text = "メッセージ";
            columnData.Width = 150;
            columnDirection.Text = "向き";
            columnDirection.Width = 200;
            ColumnHeader[] colHeaderRegValue =
              {columnNumber, columnName, columnType, columnData, columnDirection};
            detailList.Columns.AddRange(colHeaderRegValue);
        }

        string[] property = { };
        List<Communication> comList = new List<Communication>();

        private void ShowAllButton_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader(
                "C:\\Users\\ouchi\\Desktop\\CopyOfAll.txt", Encoding.GetEncoding("Shift_JIS")))
            {
                //for (int i = 0; i < 10000; i++) sr.ReadLine();
                for (int all = 1; all < 100; all++)
                {
                    clicktimes++;
                    string line = "";

                    line = sr.ReadLine();

                    property = line.Split(new string[] { " ", "　" }, StringSplitOptions.RemoveEmptyEntries);

                    int type = -1;
                    Communication com = null;
                    if (property.Length == 10)
                    {
                        type = AnalyzeType(property[7], property[8], property[9]);
                        //Console.Write(type.ToString());
                        //categorize(property[7], property[8], property[9]);
                        string toCountry = FindCountry(property[7]);
                        string fromCountry = FindCountry(property[8]);
                        com = new Communication
                        {
                            id = clicktimes - 1,
                            date = new DateTime(
                                2000 + int.Parse(property[0].Substring(0, 2)),
                                int.Parse(property[0].Substring(2, 2)),
                                int.Parse(property[0].Substring(4, 2)),
                                int.Parse(property[0].Substring(7, 2)),
                                int.Parse(property[0].Substring(9, 2)),
                                int.Parse(property[0].Substring(11, 2))),
                            frequency = property[1],
                            type = type,
                            message1 = property[7],
                            message2 = property[8],
                            message3 = property[9],
                            toCountry = toCountry,
                            fromCountry = fromCountry,
                            childId = 0,
                            isFormat = true
                        };
                    }
                    else
                    {
                        com = new Communication
                        {
                            id = clicktimes - 1,
                            date = new DateTime(
                                2000 + int.Parse(property[0].Substring(0, 2)),
                                int.Parse(property[0].Substring(2, 2)),
                                int.Parse(property[0].Substring(4, 2)),
                                int.Parse(property[0].Substring(7, 2)),
                                int.Parse(property[0].Substring(9, 2)),
                                int.Parse(property[0].Substring(11, 2))),
                            frequency = "",
                            type = type,
                            message1 = "",
                            message2 = "",
                            message3 = "",
                            toCountry = "",
                            fromCountry = "",
                            childId = 0,
                            isFormat = false
                        };
                    }
                    comList.Add(com);


                    bool isChild;
                    if (type == 0 || type == -1)
                    {
                        isChild = false;
                    }
                    else
                    {
                        isChild = ChildApply(com.id, com.message1, com.message2);
                    }
                    string[] appear = { com.id.ToString(), com.date.ToString(), com.frequency, com.message1 + " " + com.message2 + " " + com.message3, com.toCountry + " <- " + com.fromCountry };
                    allList.Items.Add(new ListViewItem(appear));
                    if (!isChild && com.type != -1)
                    {
                        cqList.Items.Add(new ListViewItem(appear));
                    }


                    //Console.WriteLine(comList[0].id.ToString());
                    //await Task.Delay(100);
                }
            }
        }

        private string FindCountry(string callsign)
        {
            try
            {
                string countryName;
                Console.WriteLine(callsign);

                if (callsign == "CQ")
                {
                    countryName = "All";
                }
                else if (countryCode.ContainsKey(callsign[0].ToString()))
                {
                    countryName = countryCode[callsign[0].ToString()];
                }
                else if (countryCode.ContainsKey(callsign[0].ToString() + callsign[1].ToString()))
                {
                    countryName = countryCode[callsign[0].ToString() + callsign[1].ToString()];
                }
                else if (countryCode.ContainsKey(callsign[0].ToString() + callsign[1].ToString() + callsign[2].ToString()))
                {
                    countryName = countryCode[callsign[0].ToString() + callsign[1].ToString() + callsign[2].ToString()];
                }
                else
                {
                    countryName = "ERROR";
                }
                return countryName;
            }
            catch
            {
                return "ERROR";
            }
        }

        private (double? lat, double? lng) ConvertLatLng(Communication com, bool isFrom)
        {
            if (isFrom)
            {
                if (com.type == 0 || com.type == 15)
                {
                    string grid = com.message3;
                    float ansLng = grid[0] - 65f + 0.1f * float.Parse(grid[2].ToString());
                    float ansLat = grid[1] - 65f + 0.1f * float.Parse(grid[3].ToString());
                    double lng = ansLng * 20 - 180 + 1;
                    double lat = ansLat * 10 - 90 + 0.5d;
                    if (callsignLocation.ContainsKey(com.message2))
                    {
                        callsignLocation[com.message2] = (lat, lng);
                    }
                    else
                    {
                        callsignLocation.Add(com.message2, (lat, lng));
                    }
                    return (lat, lng);
                }
                else
                {
                    if (callsignLocation.ContainsKey(com.message2))
                    {
                        return callsignLocation[com.message2];
                    }
                    else
                    {
                        return countryLatlng[com.fromCountry];
                    }
                }
            }
            else
            {
                if (callsignLocation.ContainsKey(com.message1))
                {
                    return callsignLocation[com.message1];
                }
                else
                {
                    return countryLatlng[com.toCountry];
                }
            }

        }

        private bool ChildApply(int id, string receiver, string sender)
        {
            try
            {
                for (int i = 2; i < 100; i++)
                {
                    Communication tester = comList[comList.Count - i];
                    if ((tester.message1 == receiver && tester.message2 == sender) ||
                    (tester.message1 == sender && tester.message2 == receiver) ||
                    (tester.message1 == "CQ" && tester.message2 == receiver) ||
                    (tester.message1 == "CQ" && tester.message2 == sender))
                    {
                        tester.childId = id;
                        try { label1.Text = comList[276].childId.ToString(); } catch { }
                        CqList_Click(null, null);

                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private int AnalyzeType(string first, string second, string third)
        {
            if (Regex.IsMatch(third, "[A-Z][A-Z][0-9][0-9]"))
            {
                if (first == "CQ") return 0;
                else if (third == "RR73") return 145;
                else return 15;
            }
            else if (Regex.IsMatch(third, "R[+-][0-9]+")) return 45;
            else if (Regex.IsMatch(third, "-?[0-9]+"))
            {
                if (third == "73") return 90;
                else return 30;
            }
            else if (third == "RRR") return 60;

            else return -1;
        }


        private void CqList_Click(object sender, EventArgs e)
        {
            detailList.Items.Clear();

            // 選択項目があるかどうかを確認する
            if (cqList.SelectedItems.Count == 0)
            {
                // 選択項目がないので処理をせず抜ける
                return;
            }

            // 選択項目を取得する
            ListViewItem itemx = cqList.SelectedItems[0];
            Communication com = comList[int.Parse(itemx.Text)];
            Display(com);
            DrawOnMap(cqList, itemx);
        }

        private void Display(Communication com)
        {
            string[] appear = { com.id.ToString(), com.date.ToString(), com.type.ToString(), com.message1 + " " + com.message2 + " " + com.message3, com.toCountry + " <- " + com.fromCountry };
            detailList.Items.Add(new ListViewItem(appear));

            if (com.childId != 0)
            {
                Display(comList[com.childId]);
            }
        }

        private void AllList_Click(object sender, EventArgs e)
        {
            if (allList.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem itemx = allList.SelectedItems[0];
            DrawOnMap(allList, itemx);
        }

        private void DetailList_Click(object sender, EventArgs e)
        {
            if (detailList.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem itemx = detailList.SelectedItems[0];
            DrawOnMap(detailList, itemx);
        }

        private void DrawOnMap(object caller, ListViewItem itemx)
        {
            //Console.WriteLine(itemx.Text);
            Communication com = comList[int.Parse(itemx.Text)];
            try
            {
                //Console.WriteLine("com.fromC:" + com.fromCountry + ", com.toC:" + com.toCountry);

                (double? fromLat, double? fromLng) = ConvertLatLng(com, true);
                //Console.WriteLine("fromLat:" + fromLat.ToString() + ", fromLng:" + fromLng.ToString());

                if (com.type == 0)
                {
                    cefBrowser.ExecuteScriptAsync("PointCQ(" + fromLat + ", " + fromLng + ")");
                }
                else
                {
                    (double? toLat, double? toLng) = ConvertLatLng(com, false);
                    //Console.WriteLine("toLat:" + toLat.ToString() + ", toLng:" + toLng.ToString());

                    if (caller == allList || caller == detailList)
                    {
                        cefBrowser.ExecuteScriptAsync("DrawLine(" + toLat + " ," + toLng + ", " + fromLat + " ," + fromLng + " , true);");
                    }
                    else //caller == cqList
                    {
                        cefBrowser.ExecuteScriptAsync("DrawLine(" + toLat + " ," + toLng + ", " + fromLat + " ," + fromLng + ", false);");
                    }
                }
            }
            catch (Exception ex)
            {
                cefBrowser.ExecuteScriptAsync("ClearEntities()");
                //Console.WriteLine("error is" + ex);
            }
        }
    }
}
