using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace ECGXmlReader;

//<sequence classCode = 'OBS' >
//  < code code='MDC_ECG_LEAD_I' codeSystem='2.16.840.1.113883.6.24' codeSystemName='MDC'/>
//  <value xsi:type='SLIST_PQ'>
//    <origin value = '0' unit='uV'/>
//    <scale value = '4.88' unit='uV'/>
//    <digits>-18 -18 -17 -17 -16 -16 -17 -15 -13 -15 -16 -16 -17 -19 -21 -21 -21 -20 -19 -19 -21 -23 -23 -23 -23 -21 -20 -20 -20 -22 -26 -29 -28 -27 -26 -25 -25 -25 -25 -27 -27 -26 -25 -23 -23 -23 -22 -23 -25 -27 -28 -27 -26 -25 -24 -24 -23 -23 -23 -26 -27 -25 -26 -29 -29 -29 -28 -27 -25 -22 -21 -19 -17 -14 -11 -10 -9 -9 -11 -13 -10 -8 -8 -10 -10 -9 -6 -4 -2 0 1 2 1 -3 -5 -7 -8 -9 -10 -10 -11 -10 -7 -5 -2 -1 -5 -6 -7 -11 -14 -13 -12 -12 -15 -18 -18 -18 -20 -21 -24 -29 -31 -31 -29 -26 -25 -26 -24 -23 -23 -24 -26 -27 -26 -25 -27 -28 -28 -30 -31 -29 -26 -23 -22 -26 -29 -29 -26 -24 -26 -26 -21 -16 -10 -2 10 23 37 55 77 99 120 139 157 167 173 171 155 125 80 23 -35 -81 -110 -127 -134 -134 -129 -118 -108 -100 -90 -76 -60 -51 -46 -40 -35 -31 -27 -26 -23 -24 -26 -29 -30 -29 -27 -27 -28 -28 -27 -27 -25 -27 -29 -26 -22 -19 -19 -20 -21 -21 -20 -19 -22 -23 -21 -17 -20 -21 -22 -24 -25 -24 -22 -19 -18 -18 -18 -21 -19 -18 -18 -19 -23 -23 -20 -17 -16 -16 -15 -14 -16 -19 -20 -19 -17 -17 -15 -16 -15 -13 -12 -11 -13 -15 -15 -16 -16 -15 -15 -14 -11 -11 -11 -13 -12 -9 -6 -8 -11 -14 -14 -12 -8 -7 -6 -7 -8 -11 -13 -13 -11 -9 -10 -9 -11 -15 -15 -14 -15 -14 -13 -16 -20 -23 -24 -22 -18 -17 -18 -21 -20 -17 -16 -15 -15 -18 -20 -17 -14 -14 -17 -19 -20 -19 -17 -17 -16 -15 -15 -16 -19 -18 -19 -18 -20 -22 -23 -22 -22 -22 -24 -26 -27 -28 -27 -27 -27 -29 -29 -29 -29 -27 -24 -22 -24 -25 -29 -33 -32 -32 -33 -33 -32 -31 -32 -34 -34 -31 -29 -28 -27 -27 -28 -28 -27 -26 -26 -26 -24 -23 -20 -21 -22 -23 -23 -23 -21 -19 -15 -13 -12 -12 -12 -12 -12 -10 -8 -6 -5 -2 -2 -5 -5 -6 -6 -9 -11 -12 -12 -12 -11 -11 -11 -10 -9 -10 -10 -10 -9 -10 -13 -16 -18 -19 -21 -22 -24 -24 -24 -24 -25 -26 -28 -28 -26 -26 -24 -25 -28 -30 -29 -30 -32 -30 -28 -28 -27 -26 -25 -29 -32 -34 -33 -33 -32 -30 -29 -33 -35 -37 -33 -26 -20 -15 -7 2 10 20 37 60 84 111 135 154 165 170 168 155 132 93 41 -19 -74 -115 -143 -155 -158 -158 -150 -136 -122 -107 -91 -75 -64 -57 -53 -47 -42 -36 -31 -25 -21 -24 -29 -30 -28 -27 -23 -23 -22 -23 -22 -24 -26 -29 -28 -28 -27 -26 -24 -22 -22 -23 -24 -25 -24 -23 -22 -21 -18 -17 -20 -20 -20 -22 -24 -22 -20 -19 -20 -18 -19 -20 -19 -18 -18 -20 -20 -18 -16 -16 -16 -15 -15 -15 -15 -14 -14 -16 -15 -16 -17 -17 -15 -13 -11 -11 -11 -11 -12 -12 -11 -9 -6 -6 -8 -10 -11 -13 -13 -12 -10 -7 -5 -3 -6 -13 -17 -18 -16 -14 -14 -14 -15 -14 -14 -16 -17 -15 -9 -8 -9 -11 -14 -17 -17 -16 -16 -17 -16 -16 -14 -15 -16 -15 -13 -13 -14 -14 -14 -13 -12 -12 -15 -17 -20 -22 -23 -21 -20 -21 -19 -22 -24 -24 -24 -25 -24 -24 -22 -19 -19 -22 -24 -26 -26 -30 -33 -33 -32 -31 -32 -34 -34 -33 -32 -31 -30 -30 -30 -31 -30 -28 -28 -27 -27 -27 -27 -28 -29 -29 -27 -26 -25 -27 -30 -28 -23 -23 -25 -25 -25 -27 -26 -27 -25 -21 -17 -16 -15 -15 -13 -12 -11 -9 -8 -8 -8 -7 -7 -6 -5 -4 -2 -4 -8 -9 -8 -8 -6 -4 -2 -2 -2 -5 -5 -5 -5 -7 -7 -8 -9 -10 -8 -8 -11 -12 -12 -14 -15 -15 -15 -17 -20 -20 -21 -22 -24 -26 -24 -22 -21 -21 -23 -23 -25 -26 -26 -24 -23 -24 -26 -28 -27 -25 -24 -24 -25 -26 -24 -22 -20 -19 -24 -27 -28 -25 -20 -17 -11 -6 -2 6 18 30 48 69 93 115 134 147 156 161 159 147 123 84 31 -28 -76 -111 -130 -140 -143 -140 -128 -115 -103 -93 -82 -69 -58 -48 -41 -36 -32 -28 -27 -27 -26 -24 -24 -24 -22 -20 -20 -19 -19 -21 -23 -24 -23 -24 -23 -23 -21 -19 -17 -18 -20 -21 -21 -21 -22 -22 -22 -19 -17 -17 -17 -17 -19 -20 -18 -18 -19 -19 -20 -18 -16 -14 -15 -18 -18 -18 -16 -14 -11 -12 -14 -13 -11 -8 -7 -9 -12 -13 -14 -12 -9 -5 -5 -10 -14 -12 -9 -5 -5 -5 -6 -5 -6 -5 -6 -5 -3 -4 -8 -10 -9 -10 -8 -6 -8 -11 -10 -10 -8 -8 -8 -8 -9 -11 -11 -9 -6 -3 -2 -5 -7 -8 -11 -14 -15 -15 -15 -14 -16 -17 -18 -16 -14 -14 -14 -13 -11 -10 -9 -10 -15 -16 -16 -16 -15 -17 -17 -16 -19 -20 -20 -22 -23 -22 -21 -21 -20 -20 -20 -22 -23 -25 -27 -29 -27 -28 -29 -28 -27 -27 -27 -27 -27 -26 -27 -28 -29 -29 -29 -28 -27 -27 -29 -30 -28 -30 -35 -37 -34 -32 -30 -31 -32 -29 -28 -24 -25 -26 -27 -27 -27 -27 -26 -24 -23 -23 -24 -22 -19 -18 -18 -17 -15 -13 -12 -11 -11 -9 -7 -8 -7 -7 -7 -6 -5 -6 -11 -13 -14 -14 -15 -14 -13 -13 -11 -10 -10 -11 -9 -8 -9 -11 -12 -13 -12 -15 -18 -18 -19 -18 -18 -18 -19 -21 -26 -28 -29 -27 -27 -28 -29 -28 -27 -27 -28 -28 -27 -26 -24 -24 -26 -28 -28 -28 -27 -25 -27 -30 -29 -30 -29 -29 -30 -30 -29 -28 -26 -26 -20 -11 -1 9 21 34 52 74 96 118 139 155 165 169 164 149 120 78 23 -35 -80 -109 -126 -135 -136 -131 -125 -115 -103 -90 -77 -65 -55 -47 -42 -38 -34 -29 -27 -27 -27 -26 -26 -28 -30 -30 -31 -30 -28 -24 -21 -22 -24 -24 -23 -24 -26 -27 -26 -25 -23 -24 -26 -25 -25 -24 -20 -21 -22 -20 -20 -22 -23 -23 -24 -27 -29 -26 -23 -22 -21 -25 -28 -28 -26 -23 -21 -20 -18 -17 -17 -20 -21 -20 -22 -25 -25 -22 -18 -15 -15 -18 -18 -16 -16 -17 -17 -17 -16 -15 -15 -20 -20 -17 -14 -12 -12 -12 -11 -11 -10 -12 -13 -15 -16 -15 -14 -14 -15 -16 -17 -19 -18 -18 -17 -17 -18 -16 -14 -15 -19 -20 -20 -22 -24 -23 -22 -21 -20 -20 -21 -22 -21 -20 -21 -22 -21 -19 -19 -21 -21 -20 -19 -20 -21 -22 -21 -22 -23 -23 -21 -21 -24 -26 -26 -26 -26 -24 -23 -23 -23 -24 -27 -29 -30 -29 -27 -25 -27 -29 -30 -30 -30 -30 -32 -34 -34 -33 -33 -34 -33 -33 -33 -34 -35 -35 -33 -32 -32 -31 -31 -30 -29 -28 -26 -29 -33 -32 -29 -27 -28 -28 -28 -27 -24 -22 -18 -15 -14 -14 -15 -13 -6 -2 -3 -6 -9 -11 -14 -14 -12 -9 -9 -7 -5 -6 -10 -12 -16 -16 -15 -14 -11 -8 -6 -7 -11 -11 -11 -10 -12 -14 -16 -20 -22 -23 -23 -22 -21 -21 -24 -29 -32 -31 -29 -28 -29 -27 -26 -26 -26 -26 -28 -28 -30 -30 -30 -30 -30 -30 -30 -31 -31 -29 -29 -30 -29 -26 -26 -30 -30 -31 -26 -19 -14 -10 -7 0 9 22 36 56 81 107 133 154 166 171 169 157 132 96 45 -14 -73 -115 -140 -153 -157 -154 -145 -135 -120 -104 -89 -75 -66 -59 -53 -48 -43 -39 -33 -29 -28 -27 -27 -27 -26 -24 -23 -22 -23 -23 -23 -22 -24 -27 -27 -27 -27 -25 -25 -26 -26 -28 -27 -27 -25 -23 -23 -22 -20 -21 -24 -24 -24 -25 -24 -24 -23 -22 -21 -19 -17 -16 -19 -24 -24 -22 -21 -21 -20 -17 -16 -15 -16 -18 -19 -21 -19 -15 -15 -16 -18 -16 -16 -15 -16 -16 -16 -15 -12 -10 -10 -11 -13 -13 -15 -16 -14 -12 -10 -9 -7 -6 -11 -15 -18 -20 -18 -15 -14 -12 -10 -9 -9 -9 -9 -11 -13 -15 -16 -15 -14 -14 -16 -14 -12 -12 -13 -13 -13 -16 -17 -17 -18 -20 -19 -19 -16 -14 -14 -13 -14 -14 -17 -18 -17 -17 -17 -18 -20 -24 -26 -27 -29 -28 -27 -27 -27 -26 -25 -24 -24 -26 -28 -28 -28 -28 -30 -31 -30 -31 -31 -30 -31 -33 -31 -29 -29 -30 -30 -31 -32 -33 -33 -33 -32 -31 -31 -31 -31 -30 -26 -25 -23 -24 -27 -27 -26 -28 -28 -28 -26 -24 -25 -25 -24 -23 -22 -18 -16 -15 -15 -13 -12 -13 -13 -13 -11 -12 -9 -9 -8 -7 -7 -8 -10 -11 -11 -11 -9 -8 -8 -9 -11 -9 -7 -5 -5 -6 -7 -7 -7 -9 -11 -13 -15 -17 -18 -19 -17 -18 -17 -17 -20 -23 -23 -22 -22 -24 -28 -29 -31 -29 -27 -27 -27 -26 -26 -27 -28 -29 -27 -26 -23 -23 -26 -29 -27 -27 -28 -27 -26 -27 -27 -27 -28 -29 -25 -20 -14 -5 4 12 21 33 50 73 95 117 137 153 160 163 159 145 118 75 19 -39 -86 -117 -136 -144 -144 -139 -131 -122 -110 -95 -78 -61 -51 -45 -42 -39 -34 -31 -28 -27 -24 -20 -20 -24 -27 -28 -28 -26 -25 -25 -27 -26 -25 -25 -24 -23 -22 -19 -19 -18 -19 -19 -18 -20 -24 -24 -24 -22 -21 -23 -23 -22 -20 -20 -19 -19 -17 -17 -19 -20 -18 -18 -18 -19 -20 -21 -20 -20 -18 -18 -19 -20 -18 -16 -14 -13 -13 -13 -12 -11 -13 -12 -11 -11 -11 -14 -16 -16 -16 -14 -12 -10 -11 -12 -12 -13 -11 -10 -11 -12 -12 -12 -11 -10 -10 -10 -10 -8 -7 -7 -7 -11 -13 -12 -12 -11 -12 -13 -15 -15 -15 -13 -12 -11 -11 -14 -15 -14 -14 -17 -19 -18 -17 -18 -16 -14 -11 -10 -12 -13 -13 -13 -16 -19 -21 -20 -20 -20 -21 -21 -20 -21 -21 -20 -21 -22 -23 -25 -26 -26 -25 -23 -23 -22 -24 -26 -28 -26 -25 -25 -26 -30 -32 -31 -32 -32 -30 -29 -29 -29 -31 -32 -31 -31 -31 -29 -29 -28 -28 -29 -29 -28 -26 -23 -24 -25 -25 -25 -26 -28 -27 -25 -23 -21 -18 -16 -14 -13 -15 -13 -13 -11 -10 -10 -9 -9 -8 -6 -6 -7 -6 -4 -2 -1 1 2 -2 -5 -6 -7 -9 -8 -5 -3 -1 0 0 -3 -6 -5 -4 -8 -11 -12 -13 -16 -17 -17 -18 -17 -20 -20 -17 -15 -19 -25 -27 -26 -26 -26 -24 -22 -22 -21 -23 -25 -25 -24 -24 -27 -29 -31 -30 -27 -26 -25 -25 -25 -26 -24 -23 -23 -25 -25 -26 -24 -20 -15 -9 -4 2 13 28 50 77 106 129 149 165 173 173 174 165 145 111 63 5 -47 -87 -113 -132 -138 -135 -125 -110 -96 -88 -77 -62 -52 -45 -41 -38 -33 -29 -27 -26 -25 -27 -25 -25 -25 -25 -23 -21 -20 -20 -19 -18 -19 -24 -26 -25 -23 -20 -19 -19 -18 -19 -19 -19 -23 -24 -24 -22 -19 -20 -20 -20 -21 -22 -21 -18 -16 -15 -15 -16 -17 -16 -17 -17 -14 -12 -13 -14 -14 -17 -18 -19 -19 -21 -22 -22 -19 -16 -15 -15 -14 -15 -15 -13 -12 -10 -10 -11 -10 -12 -15 -13 -12 -13 -13 -12 -13 -15 -17 -18 -15 -11 -12 -12 -12 -10 -9 -10 -11 -12 -13 -15 -14 -13 -11 -11 -10 -9 -10 -12 -13 -13 -14 -19 -21 -23 -24 -24 -24 -23 -19 -18 -15 -16 -17 -17 -17 -18 -17 -17 -18 -21 -23 -24 -25 -24 -23 -24 -21 -20 -20 -20 -17 -16 -19 -21 -25 -28 -28 -27 -27 -26 -26 -28 -28 -29 -29 -31 -30 -29 -29 -30 -32 -31 -31 -31 -30 -31 -30 -30 -29 -28 -27 -26 -29 -32 -33 -33 -32 -31 -29 -29 -27 -26 -27 -28 -28 -29 -25 -23 -23 -26 -26 -24 -23 -23 -22 -19 -17 -15 -14 -15 -14 -13 -11 -10 -8 -9 -10 -12 -10 -8 -7 -9 -12 -13 -10 -9 -9 -10 -8 -6 -7 -7 -6 -6 -10 -12 -13 -17 -20 -20 -20 -20 -21 -22 -22 -23 -23 -23 -23 -24 -25 -25 -24 -27 -27 -24 -24 -26 -28 -29 -27 -29 -31 -32 -31 -31 -32 -33 -31 -28 -25 -24 -26 -29 -32 -33 -31 -32 -33 -31 -26 -24 -21 -16 -10 0 13 26 41 61 82 103 126 146 159 166 164 151 124 84 30 -31 -83 -123 -146 -157 -156 -153 -146 -137 -125 -111 -95 -79 -64 -51 -43 -39 -36 -31 -30 -31 -30 -28 -25 -24 -26 -29 -29 -29 -27 -27 -28 -28 -23 -23 -22 -23 -24 -24 -23 -24 -25 -26 -27 -24 -20 -17 -18 -22 -24 -26 -28 -26 -24 -23 -22 -21 -21 -20 -17 -15 -16 -17 -17 -17 -18 -18 -16 -15 -17 -19 -20 -19 -17 -15 -14 -15 -15 -13 -11 -14 -12 -11 -12 -12 -12 -12 -11 -11 -13 -14 -14 -13 -13 -13 -11 -10 -9 -7 -7 -7 -6 -6 -8 -10 -10 -9 -9 -10 -11 -11 -9 -7 -7 -8 -7 -9 -11 -10 -9 -12 -13 -18 -18 -16 -15 -15 -13 -11 -11 -14 -18 -19 -20 -19 -16 -14 -13 -14 -13 -13 -13 -14 -17 -19 -19 -20 -18 -16 -18 -20 -23 -23 -22 -21 -20 -21 -21 -22 -23 -25 -26 -26 -27 -28 -27 -26 -29 -30 -29 -30 -28 -27 -27 -29 -29 -29 -29 -29 -30 -30 -27 -27 -32 -34 -33 -31 -29 -27 -28 -29 -29 -30 -30 -30 -28 -25 -23 -20 -18 -22 -27 -26 -26 -24 -23 -24 -21 -19 -16 -15 -14 -12 -11 -10 -8 -7 -4 -7 -10 -11 -9 -7 -6 -5 -6 -8 -9 -10 -10 -10 -9 -8 -8 -8 -9 -8 -5 -5 -6 -7 -6 -7 -10 -12 -16 -18 -18 -19 -18 -19 -19 -20 -20 -21 -23 -24 -21 -21 -21 -23 -24 -24 -24 -26 -27 -27 -27 -26 -25 -24 -23 -23 -25 -27 -29 -29 -29 -30 -31 -33 -30 -30 -29 -27 -26 -23 -22 -21 -19 -15 -8 1 12 24 39 57 77 97 118 138 152 160 158 152 134 108 68 13 -43 -88 -116 -133 -142 -142 -135 -125 -116 -106 -93 -77 -63 -54 -48 -41 -33 -28 -26 -27 -28 -27 -29 -31 -30 -28 -26 -24 -24 -25 -25 -25 -23 -19 -20 -20 -20 -20 -22 -21 -21 -22 -22 -22 -22 -24 -22 -19 -18 -17 -15 -14 -14 -15 -18 -20 -20 -21 -20 -19 -18 -18 -20 -21 -20 -18 -17 -17 -18 -18 -16 -15 -14 -16 -16 -14 -14 -13 -12 -11 -12 -15 -14 -14 -12 -11 -10 -10 -12 -12 -11 -11 -9 -7 -10 -11 -10 -10 -9 -7 -6 -8 -8 -7 -8 -10 -11 -11 -11 -12 -14 -13 -11 -11 -10 -10 -11 -10 -9 -9 -13 -15 -15 -14 -12 -10 -10 -12 -13 -11 -10 -12 -13 -15 -16 -18 -17 -16 -15 -13 -14 -15 -14 -14 -16 -15 -14 -14 -14 -15 -14 -14 -16 -18 -20 -20 -18 -19 -22 -24 -25 -24 -23 -21 -22 -26 -27 -29 -28 -29 -28 -28 -28 -28 -27 -26 -27 -27 -29 -28 -28 -26 -25 -27 -28 -28 -25 -25 -28 -31 -30 -28 -28 -28 -27 -25 -24 -21 -21 -23 -23 -24 -24 -21 -15 -14 -18 -21 -21 -18 -16 -16 -17 -16 -15 -13 -12 -11 -9 -7 -5 -4 -4 -4 -2 -2 -5 -8 -9 -9 -11 -12 -11 -12 -10 -7 -5 -6 -8 -9 -10 -11 -9 -8 -10 -11 -12 -12 -14 -16 -17 -19 -16 -15 -16 -18 -21 -24 -24 -24 -22 -22 -26 -29 -28 -28 -28 -25 -23 -21 -21 -23 -23 -24 -23 -23 -29 -34 -34 -34 -33 -31 -28 -26 -28 -26 -23 -19 -12 -4 2 8 15 29 47 70 95 117 136 153 164 171 169 156 130 93 40 -17 -64 -98 -118 -129 -128 -123 -117 -107 -98 -87 -74 -62 -54 -45 -38 -34 -31 -29 -26 -23 -22 -19 -18 -17 -16 -21 -25 -26 -25 -22 -22 -26 -26 -26 -26 -25 -23 -21 -24 -23 -24 -24 -23 -22 -23 -24 -22 -20 -17 -17 -18 -17 -17 -16 -16 -17 -20 -21 -21 -20 -18 -18 -18 -19 -15 -13 -13 -12 -12 -15 -16 -16 -17 -18 -17 -14 -12 -11 -11 -16 -19 -19 -19 -15 -14 -15 -15 -16 -15 -14 -14 -14 -12 -12 -11 -11 -10 -9 -8 -7 -8 -8 -12 -15 -15 -15 -15 -15 -13 -13 -10 -10 -10 -12 -11 -11 -12 -13 -15 -16 -16 -16 -16 -15 -17 -18 -15 -15 -14 -13 -9 -8 -12 -15 -17 -19 -20 -19 -16 -16 -18 -19 -21 -20 -19 -20 -20 -17 -19 -21 -22 -23 -24 -24 -24 -25 -25 -25 -24 -24 -24 -25 -26 -26 -26 -25 -26 -26 -24 -26 -30 -29 -29 -30 -31 -31 -30 -31 -30 -31 -31 -29 -27 -24 -24 -23 -28 -35 -37 -38 -35 -31 -29 -26 -26 -27 -28 -30 -30 -28 -25 -24 -23 -24 -23 -20 -18 -17 -17 -16 -13 -10 -10 -10 -10 -11 -11 -9 -8 -7 -7 -9 -7 -4 -2 -3 -6 -6 -6 -9 -10 -9 -8 -7 -7 -8 -12 -14 -12 -11 -14 -19 -19 -18 -20 -21 -23 -24 -23 -24 -24 -24 -27 -28 -29 -29 -29 -29 -30 -30 -29 -29 -28 -27 -25 -23 -23 -28 -29 -28 -27 -25 -26 -33 -32 -30 -29 -28 -27 -29 -31 -31 -27 -20 -14 -7 2 12 24 37 54 76 101 126 147 161 169 170 161 139 103 56 -2 -59 -105 -133 -149 -154 -154 -149 -140 -127 -111 -96 -82 -69 -58 -51 -46 -41 -39 -34 -31 -29 -26 -24 -24 -25 -24 -25 -26 -23 -18 -15 -18 -21 -23 -24 -25 -27 -26 -24 -22 -21 -20 -20 -21 -23 -22 -21 -21 -18 -17 -16 -18 -20 -22 -21 -20 -18 -18 -17 -17 -19 -20 -22 -21 -19 -18 -19 -21 -20 -18 -17 -16 -14 -14 -14 -14 -13 -13 -13 -13 -11 -9 -8 -7 -6 -7 -9 -9 -7 -6 -5 -8 -13 -13 -11 -9 -8 -8 -6 -3 -6 -10 -11 -9 -6 -8 -8 -9 -10 -12 -13 -11 -9 -7 -5 -5 -6 -9 -10 -10 -12 -12 -11 -10 -10 -10 -8 -8 -7 -4 -2 -5 -10 -13 -13 -11 -11 -10 -10 -8 -10 -12 -13 -13 -14 -13 -13 -15 -17 -17 -17 -17 -19 -17 -16 -17 -19 -24 -25 -27 -27 -24 -26 -27 -27 -26 -26 -27 -25 -25 -27 -29 -28 -27 -27 -27 -26 -24 -23 -23 -25 -25 -25 -28 -31 -31 -30 -29 -28 -29 -29 -29 -27 -27 -25 -23 -21 -21 -21 -23 -22 -23 -24 -21 -20 -19 -17 -15 -11 -11 -10 -11 -9 -8 -6 -6 -9 -11 -9 -8 -8 -9 -8 -7 -9 -9 -10 -10 -8 -7 -6 -6 -6 -8 -10 -8 -6 -5 -4 -3 -3 -3 -4 -4 -7 -11 -16 -18 -17 -17 -19 -21 -23 -24 -24 -27 -27 -27 -25 -24 -25 -25 -23 -22 -23 -27 -29 -30 -29 -26 -26 -27 -26 -26 -25 -26 -25 -23 -23 -23 -22 -23 -25 -26 -25 -23 -19 -15 -11 -3 6 17 32 53 76 96 114 131 146 154 157 156 147 125 87 33 -26 -74 -106 -123 -131 -131 -124 -114 -103 -92 -81 -69 -56 -49 -44 -37 -32 -26 -24 -25 -25 -26 -27 -27 -27 -26 -25 -25 -25 -25 -23 -21 -19 -20 -22 -22 -22 -21 -22 -26 -27 -25 -24 -23 -22 -22 -21 -21 -21 -19 -17 -17 -20 -23 -24 -23 -21 -21 -20 -19 -17 -15 -15 -15 -16 -15 -14 -14 -14 -14 -15 -17 -19 -17 -16 -15 -15 -15 -15 -16 -16 -15 -14 -12 -9 -7 -7 -7 -8 -10 -11 -12 -11 -11 -10 -11 -8 -6 -9 -11 -10 -9 -12 -13 -13 -15 -13 -10 -8 -6 -7 -12 -14 -14 -14 -14 -13 -12 -14 -16 -16 -14 -14 -14 -13 -14 -15 -17 -15 -14 -13 -12 -13 -12 -13 -14 -15 -16 -16 -17 -16 -13 -8 -9 -13 -16 -18 -19 -19 -21 -20 -20 -20 -21 -22 -20 -18 -16 -15 -18 -22 -25 -27 -27 -27 -28 -27 -30 -29 -27 -26 -24 -26 -27 -28 -30 -28 -25 -23 -22 -22 -26 -30 -30 -30 -31 -32 -33 -34 -33 -31 -29 -26 -27 -26 -26 -25 -25 -25 -24 -23 -24 -22 -20 -21 -20 -20 -21 -20 -19 -16 -14 -12 -11 -7 -2 1 -4 -8 -7 -3 -4 -3 -7 -10 -10 -10 -10 -11 -9 -7 -7 -5 -4 -5 -8 -9 -9 -11 -11 -10 -12 -16 -20 -19 -20 -19 -19 -21 -21 -21 -23 -25 -28 -30 -32 -31 -32 -29 -28 -28 -30 -32 -32 -31 -30 -29 -28 -28 -29 -27 -25 -25 -24 -23 -24 -24 -24 -28 -27 -27 -34 -37 -33 -29 -23 -18 -10 0 10 24 42 65 88 110 135 157 171 178 180 171 148 111 61 -1 -63 -109 -138 -153 -156 -154 -149 -139 -125 -111 -99 -83 -68 -58 -52 -48 -41 -35 -32 -30 -29 -28 -26 -23 -24 -24 -26 -25 -26 -27 -25 -23 -23 -23 -21 -18 -19 -22 -21 -18 -15 -16 -15 -16 -18 -21 -25 -26 -29 -28 -24 -23 -24 -22 -21 -21 -23 -22 -22 -24 -26 -22 -18 -17 -18 -20 -20 -20 -19 -19 -21 -17 -13 -12 -11 -10 -10 -11 -12 -15 -16 -15 -15 -15 -14 -13 -13 -12 -14 -16 -16 -14 -12 -10 -8 -4 0 1 -3 -5 -13 -16 -15 -13 -13 -12 -12 -11 -10 -10 -10 -9 -10 -13 -15 -19 -22 -21 -20 -18 -15 -14 -12 -12 -11 -12 -14 -14 -14 -14 -15 -14 -13 -11 -11 -9 -9 -12 -15 -17 -18 -19 -20 -22 -21 -18 -16 -13 -15 -17 -19 -21 -21 -22 -24 </digits>
//  </value>
//</sequence>
public class ECGDataItem
{
    private string xsiType = "SLIST_PQ";

    public static Dictionary<int, string> LeadIndexNames = new Dictionary<int, string>() {
         {1, "MDC_ECG_LEAD_I"},
         {2 , "MDC_ECG_LEAD_II" },
         {3 , "MDC_ECG_LEAD_III" },
         {4 , "MDC_ECG_LEAD_AVR" },
         {5 , "MDC_ECG_LEAD_AVL" },
         {6 , "MDC_ECG_LEAD_AVF" },
         {7 , "MDC_ECG_LEAD_V1" },
         {8 , "MDC_ECG_LEAD_V2" },
         {9 , "MDC_ECG_LEAD_V3" },
         {10 , "MDC_ECG_LEAD_V4" },
         {11 , "MDC_ECG_LEAD_V5" },
         {12 , "MDC_ECG_LEAD_V6" }
    };

    public static Dictionary<string, string> LeadShortNames = new Dictionary<string, string>() {
         {"MDC_ECG_LEAD_I", "I" },
         {"MDC_ECG_LEAD_II", "II" },
         {"MDC_ECG_LEAD_III", "III" },
         {"MDC_ECG_LEAD_AVR", "aVR" },
         {"MDC_ECG_LEAD_AVL", "aVL" },
         {"MDC_ECG_LEAD_AVF", "aVF" },
         {"MDC_ECG_LEAD_V1", "V1" },
         {"MDC_ECG_LEAD_V2", "V2" },
         {"MDC_ECG_LEAD_V3", "V3" },
         {"MDC_ECG_LEAD_V4", "V4" },
         {"MDC_ECG_LEAD_V5", "V5" },
         {"MDC_ECG_LEAD_V6", "V6" }
    };

    public string[] codes = [ "MDC_ECG_LEAD_I", "MDC_ECG_LEAD_II", "MDC_ECG_LEAD_III", "MDC_ECG_LEAD_aVR",
                               "MDC_ECG_LEAD_aVL", "MDC_ECG_LEAD_aVF", "MDC_ECG_LEAD_V1", "MDC_ECG_LEAD_V2",
                               "MDC_ECG_LEAD_V3", "MDC_ECG_LEAD_V4", "MDC_ECG_LEAD_V5","MDC_ECG_LEAD_V6"];

    private string classCode;
    private string code;
    private string codeSystem;
    private string codeSystemName;
    private string origin_value;
    private string origin_unit;
    private string scale_value;
    private string scale_unit;
    public short[] digits;

    private short min_value = 300;
    private short max_value = -300;
    public string ClassCode
    {
        get { return classCode; }
        set { classCode = value; }
    }

    public string XsiType
    {
        get { return xsiType; }
        set { xsiType = value; }
    }

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public string CodeSystem
    {
        get { return codeSystem; }
        set { codeSystem = value; }
    }

    public string CodeSystemName
    {
        get { return codeSystemName; }
        set { codeSystem = value; }
    }

    public string OriginValue
    {
        get { return origin_value; }
        set { origin_value = value; }
    }

    public string OriginUnit
    {
        get { return origin_unit; }
        set { origin_unit = value; }
    }

    public string ScaleValue
    {
        get { return scale_value; }
        set { scale_value = value; }
    }

    public string ScaleUnit
    {
        get { return scale_unit; }
        set { scale_unit = value; }
    }

    public string Origin { get { return $"{origin_value} {origin_unit}"; } }
    //public string OriginUnit { get { return origin_unit; } }

    public string Scale { get { return $"{scale_value} {scale_unit}"; } }
    //public string ScaleUnit { get { return scale_unit; } }

    public short MaxValue { get { return max_value; } }

    public short MinValue { get { return min_value; } }

    // public string Lead_Origon_Scale { get { return $"{LeadNames[code.ToUpper()]}|{origin_value}/{origin_unit}|{scale_value}/{scale_unit}"; } }

    // 获取P波
    private const int SamplingFrequency = 500;  // 500 Hz
    private const int SampleCount = 5000;

    // Bandpass filter settings
    private const double LowCutoff = 0.5;
    private const double HighCutoff = 40.0;

    // 10 秒时间轴
    //                                             START, STEP,                     STOP
    public double[] Timeline = Generate.LinearRange(0.0F, 1.0F / SamplingFrequency, 10.0F); // 时间轴 (10秒)
    public double[] FilteredEcg;    // = [];

    // 检测QRS复合波（R峰）
    public List<int> QRSPeaks;      // = [];

    // 检测P波并标记起止位置
    public List<(int Start, int End, int Peak)> Waves;  // = [];

    public string Log()
    {
        return $"{code} {codeSystemName} {xsiType} {Origin} {Scale} {digits.Length}";
    }

    public ECGDataItem(XmlNode node, XmlNamespaceManager ns)
    {
        classCode = (node.Attributes.Count == 0) ? string.Empty : node.Attributes.GetNamedItem("classCode").Value;

        XmlNode n = node.SelectSingleNode("ns:code", ns);
        if (n != null)
        {
            code = (n as XmlElement).HasAttribute("code") ?
                n.Attributes.GetNamedItem("code").Value.ToString() : string.Empty;

            codeSystem = (n as XmlElement).HasAttribute("codeSystem") ?
                n.Attributes.GetNamedItem("codeSystem").Value : string.Empty;

            codeSystemName = (n as XmlElement).HasAttribute("codeSystemName") ?
                n.Attributes.GetNamedItem("codeSystemName").Value : string.Empty;
        }

        n = node.SelectSingleNode("ns:value", ns);
        if (n != null && n.HasChildNodes)
        {
            xsiType = n.Attributes.GetNamedItem("xsi:type").Value.ToString();

            XmlNode vn = n.SelectSingleNode("ns:origin", ns);
            if (n != null && n.HasChildNodes)
            {
                origin_value = (vn as XmlElement).HasAttribute("value") ?
                    vn.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

                origin_unit = (vn as XmlElement).HasAttribute("unit") ?
                    vn.Attributes.GetNamedItem("unit").Value.ToString() : string.Empty;
            }

            vn = n.SelectSingleNode("ns:scale", ns);
            if (n != null && n.HasChildNodes)
            {
                scale_value = (vn as XmlElement).HasAttribute("value") ?
                    vn.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

                scale_unit = (vn as XmlElement).HasAttribute("unit") ?
                    vn.Attributes.GetNamedItem("unit").Value.ToString() : string.Empty;
            }

            vn = n.SelectSingleNode("ns:digits", ns);
            if (n != null && n.HasChildNodes)
            {
                // string s = vn.InnerText.Replace("\\r", "").Replace("\\n", "").Trim();
                StringBuilder sb = new StringBuilder();

                StringReader strReader = new StringReader(vn.InnerText.Trim());
                while (true)
                {
                    string s = strReader.ReadLine();
                    if (s != null)
                    {
                        sb.Append(s.Trim() + " ");
                    }
                    else
                    {
                        break;
                    }
                }

                string[] ds = sb.ToString().Trim().Split(new char[] { ' ' });

                digits = new Int16[ds.Length];

                min_value = 300;
                max_value = -300;
                for (int i = 0; i < ds.Length; i++)
                {
                    digits[i] = Convert.ToInt16(ds[i]);
                    if (digits[i] > max_value) max_value = digits[i];
                    if (digits[i] < min_value) min_value = digits[i];
                }

                Debug.WriteLine(digits.Length);
            }
        }
    }

    // stored in sqlite (use lead II):
    // {
    //  "ClassCode":"OBS","XsiType":"SLIST_PQ","Code":"MDC_ECG_LEAD_II",
    //  "CodeSystem":"2.16.840.1.113883.6.24","CodeSystemName":"MDC",
    //  "OriginValue":"0","OriginUnit":"uV",
    //  "ScaleValue":"4.88","ScaleUnit":"uV"
    // }
    public ECGDataItem(ECGDataItemDTO dto, int idx, short[] data)
    {
        classCode = dto.ClassCode;
        xsiType = dto.XsiType;
        code = codes[idx];      // dto.Code = MDC_ECG_LEAD_II
        codeSystem = dto.CodeSystem;
        codeSystemName = dto.CodeSystemName;
        origin_value = dto.OriginValue;
        origin_unit = dto.OriginUnit;
        scale_value = dto.ScaleValue;
        scale_unit = dto.ScaleUnit;

        int len = 5000;
        // digits = new short[len]; 
        digits = data.Skip(idx * len).Take(len).ToArray();    // new short[len];
        // Array.Copy(data, idx * len, digits, 0, len);
        // Buffer.BlockCopy(data, idx * len, digits, 0, len);
    }

    public bool Export2CSV(string csvFile, float TS_Start, float TS_Step, float Scale, int maxOutputLimit = 6000)
    {
        bool b = false;

        try
        {
            StringBuilder sb = new StringBuilder();

            string s = "TS,Reading,Reading10,Reading5,Reading25,Reading2,Flag\n";         //: "TS,Reading\n";
            sb.Append(s);

            float TS = TS_Start;                // 0.0F;
            float step = TS_Step;               // 500.0F / digits.Length;
            float scale = Scale;                // 10.0F
            int flag = 5;
            int maxOutput = 0;

            foreach (int reading in digits)
            {
                float r10 = (float)reading / 10F;
                float r5 = (float)reading / 5F;
                float r25 = (float)reading / 2.5F;
                float r2 = (float)reading / 2.0F;

                s = $"{TS},{reading},{r10},{r5},{r25},{r2},{flag}\n"; // : $"{TS},{(float)reading / scale}\n";
                sb.Append(s);
                TS += step;

                maxOutput += 1;
                if (maxOutput > maxOutputLimit) break;
            }

            File.WriteAllText(csvFile, sb.ToString());

            sb.Clear();

            b = true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }

        return b;
    }

    public bool Export2CSVHalf(string csvFile, int TS_Start = 0,
                    int TS_Step = 1,
                    float Scale = 1F,
                    int maxOutputLimit = 5000)
    {
        bool b = false;

        try
        {
            StringBuilder sb = new StringBuilder();

            string s = "TS,Reading,Flag,TS2,Reading2,Flag2\n";         //: "TS,Reading\n";
            sb.Append(s);

            float scale = Scale;                // 10.0F
            int flag = 5;
            // int maxOutput = 0;

            int half = digits.Length / 2;

            short max = (short)(digits.Max<short>() / (short)2);
            short min = (short)(digits.Min<short>() / (short)2);

            int TSu = 1;                // 0.0F;
            int TSl = half - 500;             // + 1;

            for (int i = 0; i < half + 500; i++)
            {
                short ru = digits[i];
                if (ru < min)
                {
                    ru = min;
                }
                if (ru > max)
                {
                    ru = max;
                }

                int l = i + half - 500;
                short rl = (l > 5000) ? (short)0 : digits[l];
                if (rl < min)
                {
                    rl = min;
                }
                if (rl > max)
                {
                    rl = max;
                }

                //float r10 = (float)reading / 10F;
                //float r5 = (float)reading / 5F;
                //float r25 = (float)reading / 2.5F;
                //float r2 = (float)reading / 2.0F;

                s = $"{TSu},{ru},{flag},{TSl},{rl},{flag}\n"; // : $"{TS},{(float)reading / scale}\n";
                sb.Append(s);

                TSu += TS_Step;
                TSl += TS_Step;

                //maxOutput += 1;
                //if (maxOutput > maxOutputLimit) break;
            }

            File.WriteAllText(csvFile, sb.ToString());

            sb.Clear();

            b = true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }

        return b;
    }

    public List<LabelInfo> GetLabels()
    {
        List<LabelInfo> labels = [];

        //double[] ecgSignal = t.Select(x => Math.Sin(2 * Math.PI * 1.0 * x) + 0.5 * Math.Sin(2 * Math.PI * 5.0 * x)).ToArray(); // 模拟ECG信号
        double[] ecgSignal = [.. digits.Select(x => (double)x)];

        // 2. 预处理：滤波（去除高频噪声和基线漂移）
        double[] filteredEcg = BandpassFilter(ecgSignal, LowCutoff, HighCutoff, SamplingFrequency);

        // 3. 检测QRS复合波（R峰）
        List<int> rPeaks = FindRPeaks(filteredEcg, SamplingFrequency);

        // 4. 检测P波并标记起止位置
        List<(int Start, int End)> pWaveRanges = [];
        foreach (int rPeak in rPeaks)
        {
            int pWaveStart = rPeak - (int)(0.2 * SamplingFrequency); // P波开始位置（200毫秒前）
            if (pWaveStart < 0) continue;   // QRS 波太靠前
            int pWaveEnd = rPeak - (int)(0.08 * SamplingFrequency);  // P波结束位置（120毫秒前）

            // 确保起止位置在数组范围内
            pWaveStart = Math.Max(pWaveStart, 0);
            pWaveEnd = Math.Min(pWaveEnd, filteredEcg.Length - 1);

            // 在P波段内寻找峰值
            double[] pWaveSegment = filteredEcg.Skip(pWaveStart).Take(pWaveEnd - pWaveStart).ToArray();
            List<int> pPeaks = FindPeaks(pWaveSegment, 0.3 * pWaveSegment.Max());

            if (pPeaks.Count > 0)
            {
                // 记录P波的起止位置
                pWaveRanges.Add((pWaveStart, pWaveEnd));
            }
        }

        foreach (var range in pWaveRanges)
        {
            string ln = LeadShortNames[this.code.ToUpper()];
            labels.Add(new LabelInfo("P0", ln, range.Start, 0, range.End, 0, "SYSTEM"));
        }

        return labels;
    }


    /// <summary>
    /// 仅用于可视化
    /// </summary>
    /// <returns></returns>
    public bool PreLabelling()
    {
        try
        {
            // 1. 生成模拟ECG信号
            //

            // 模拟数据
            //double[] ecgSignal = t.Select(x => Math.Sin(2 * Math.PI * 1.0 * x) + 0.5 * Math.Sin(2 * Math.PI * 5.0 * x)).ToArray(); // 模拟ECG信号
            double[] ecgSignal = digits.Select(x => (double)x).ToArray();

            // 2. 预处理：滤波（去除高频噪声和基线漂移）
            FilteredEcg = BandpassFilter(ecgSignal, LowCutoff, HighCutoff, SamplingFrequency);

            // 3. 检测QRS复合波（R峰）
            QRSPeaks = FindRPeaks(FilteredEcg, SamplingFrequency);

            // 4. 检测P波并标记起止位置
            Waves = [];
            foreach (int rPeak in QRSPeaks)
            {
                int pWaveStart = rPeak - (int)(0.2 * SamplingFrequency); // P波开始位置（200毫秒前）
                if (pWaveStart < 0) continue;   // QRS 波太靠前
                int pWaveEnd = rPeak - (int)(0.08 * SamplingFrequency);  // P波结束位置（120毫秒前）

                // 确保起止位置在数组范围内
                pWaveStart = Math.Max(pWaveStart, 0);
                pWaveEnd = Math.Min(pWaveEnd, FilteredEcg.Length - 1);

                // 在P波段内寻找峰值
                double[] pWaveSegment = FilteredEcg.Skip(pWaveStart).Take(pWaveEnd - pWaveStart).ToArray();
                List<int> pPeaks = FindPeaks(pWaveSegment, 0.3 * pWaveSegment.Max());

                if (pPeaks.Count > 0)
                {
                    int peak = pWaveStart + pPeaks[0];

                    switch (pPeaks.Count)
                    {
                        case 1:
                            peak = pWaveStart + pPeaks[0];
                            break;
                        case 2:
                            peak = (ecgSignal[pWaveStart + pPeaks[0]] > ecgSignal[pWaveStart + pPeaks[1]]) ? (pWaveStart + pPeaks[0]) : (pWaveStart + pPeaks[1]);
                            break;
                        default:
                            peak = GetPWavePeakIndex(pWaveStart, pPeaks.ToArray());
                            break;
                    }
                    // 记录P波的起止位置+峰值位置
                    Waves.Add((pWaveStart, pWaveEnd, peak));
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    // 带通滤波器
    //private double[] BandpassFilter(double[] data, double lowcut, double highcut, double fs, int order = 4)
    //{
    //    var bandpass = new OnlineBandpassFilter(lowcut, highcut, fs, order);
    //    return bandpass.ProcessSamples(data);
    //}

    private double[] BandpassFilter(double[] data, double lowCutoff, double highCutoff, int samplingRate)
    {
        // Convert data to Complex numbers for FFT
        var complexSignal = new System.Numerics.Complex[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            complexSignal[i] = new System.Numerics.Complex(data[i], 0);
        }

        // Apply Fast Fourier Transform (FFT)
        Fourier.Forward(complexSignal, FourierOptions.Matlab);

        // Frequency Resolution
        double freqResolution = (double)samplingRate / data.Length;

        // Bandpass filter in frequency domain
        for (int i = 0; i < complexSignal.Length; i++)
        {
            double frequency = i * freqResolution;

            // Zero out frequencies outside the desired range
            if (frequency < lowCutoff || frequency > highCutoff)
            {
                complexSignal[i] = System.Numerics.Complex.Zero;
            }
        }

        // Inverse FFT to get filtered signal
        Fourier.Inverse(complexSignal, FourierOptions.Matlab);

        // Extract real part of the signal
        double[] filteredData = new double[data.Length];
        for (int i = 0; i < complexSignal.Length; i++)
        {
            filteredData[i] = complexSignal[i].Real;
        }

        return filteredData;
    }

    // 检测R峰
    private List<int> FindRPeaks(double[] data, double fs)
    {
        double height = data.Max() * 0.5;
        int distance = (int)(fs * 0.6);
        return FindPeaks(data, height, distance);
    }

    // 检测峰值
    private List<int> FindPeaks(double[] data, double height, int? distance = null)
    {
        List<int> peaks = new List<int>();
        for (int i = 1; i < data.Length - 1; i++)
        {
            if (data[i] > height && data[i] > data[i - 1] && data[i] > data[i + 1])
            {
                if (distance.HasValue && peaks.Any() && i - peaks.Last() < distance)
                {
                    if (data[i] > data[peaks.Last()])
                    {
                        peaks.RemoveAt(peaks.Count - 1);
                        peaks.Add(i);
                    }
                }
                else
                {
                    peaks.Add(i);
                }
            }
        }
        return peaks;
    }

    private int GetPWavePeakIndex(int start, int[] pPeaks)
    {
        double[] peakValues = new double[pPeaks.Length];
        for (int idx = 0; idx < pPeaks.Length; idx++)
        {
            peakValues[idx] = (double)digits[start + pPeaks[idx]];
        }

        int maxIndex = peakValues.ToList().LastIndexOf(peakValues.Max());
        return start + pPeaks[maxIndex];
    }

}

public class ECGDataItemDTO
{
    public string ClassCode { get; set; }
    public string XsiType { get; set; }
    public string Code { get; set; }
    public string CodeSystem { get; set; }
    public string CodeSystemName { get; set; }
    public string OriginValue { get; set; }
    public string OriginUnit { get; set; }
    public string ScaleValue { get; set; }
    public string ScaleUnit { get; set; }

    public ECGDataItemDTO() { }

    public ECGDataItemDTO(string classCode, string xsiType, string code, string codeSystem, string codeSystemName, string originValue, string originUnit, string scaleValue, string scaleUnit)
    {
        ClassCode = classCode;
        XsiType = xsiType;
        Code = code;
        CodeSystem = codeSystem;
        CodeSystemName = codeSystemName;
        OriginValue = originValue;
        OriginUnit = originUnit;
        ScaleValue = scaleValue;
        ScaleUnit = scaleUnit;
    }

    public ECGDataItemDTO(ECGDataItem di)
    {
        ClassCode = di.ClassCode;
        XsiType = di.XsiType;
        Code = di.Code;
        CodeSystem = di.CodeSystem;
        CodeSystemName = di.CodeSystemName;
        OriginValue = di.OriginValue;
        OriginUnit = di.OriginUnit;
        ScaleValue = di.ScaleValue;
        ScaleUnit = di.ScaleUnit;
    }

    public string Serialize()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            // IgnoreReadOnlyProperties = true,
            // WriteIndented = true
        };

        string json = JsonSerializer.Serialize<ECGDataItemDTO>(this, options);

        Debug.WriteLine(json);

        return json;
    }

    public static ECGDataItemDTO DeserializeFromFile(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        ECGDataItemDTO dto = JsonSerializer.Deserialize<ECGDataItemDTO>(jsonString)!;

        Debug.WriteLine($"Code: {dto.Code}");
        Debug.WriteLine($"CodeSystem: {dto.CodeSystem}");
        Debug.WriteLine($"Scale: {dto.ScaleValue}/{dto.ScaleUnit}");

        return dto;
    }

    public static ECGDataItemDTO DeserializeFromText(string jsonText)
    {
        ECGDataItemDTO dto = JsonSerializer.Deserialize<ECGDataItemDTO>(jsonText)!;

        Debug.WriteLine($"Code: {dto.Code}");
        Debug.WriteLine($"CodeSystem: {dto.CodeSystem}");
        Debug.WriteLine($"Scale: {dto.ScaleValue}/{dto.ScaleUnit}");

        return dto;
    }

}