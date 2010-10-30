Option Strict On
Option Explicit On

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports AddressStandardizationSolution

''' <summary>
''' Tests the address line standardization method
''' </summary>
<TestClass()> _
Public Class AddressLineStandardizationTest
	''' <summary>
	''' The AddressStandardizationSolution object to run the tests against
	''' </summary>
	Protected a As AddressStandardizationSolution.AddressStandardizationSolution = New AddressStandardizationSolution.AddressStandardizationSolution

	Private testContextInstance As TestContext

	''' <summary>
	''' Gets or sets the test context which provides
	''' information about and functionality for the current test run.
	''' </summary>
	Public Property TestContext() As TestContext
		Get
			Return testContextInstance
		End Get
		Set(ByVal value As TestContext)
			testContextInstance = value
		End Set
	End Property

	''' <summary>
	''' Runs the given address through the AddressLineStandardization method
	''' </summary>
	''' <param name="address">the address to standardize</param>
	''' <returns>the standardized address</returns>
	Protected Function t(ByVal address As String) As String
		Return a.AddressLineStandardization(address)
	End Function


	<TestMethod()> _
	Public Sub test010000()
		Assert.AreEqual("842 31ST ST", t("842 31 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test100000()
		Assert.AreEqual("842 32ND ST", t("842 32 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test200000()
		Assert.AreEqual("842 33RD ST", t("842 33 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test300000()
		Assert.AreEqual("842 34TH ST", t("842 34 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test400000()
		Assert.AreEqual("842 11TH ST", t("842 11 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test500000()
		Assert.AreEqual("842 12TH ST", t("842 12 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test600000()
		Assert.AreEqual("842 13TH ST", t("842 13 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test700000()
		Assert.AreEqual("842 14TH ST", t("842 14 STREET"))
	End Sub
	<TestMethod()> _
	Public Sub test900000()
		Assert.AreEqual("842 E 1700 S", t("842 East 1700 South"))
	End Sub
	<TestMethod()> _
	Public Sub test1000000()
		Assert.AreEqual("55 39.2 RD", t("55 39.2 RD"))
	End Sub
	<TestMethod()> _
	Public Sub test1100000()
		Assert.AreEqual("101 1/2 MAIN ST", t("101 1/2 MAIN		ST"))
	End Sub
	<TestMethod()> _
	Public Sub test1200000()
		Assert.AreEqual("101 1/2 MAIN ST", t("101 1/2 MAIN  ST"))
	End Sub
	<TestMethod()> _
	Public Sub test1300000()
		Assert.AreEqual("11 1/2 MAIN ST", t("Eleven 1/2 MAIN ST."))
	End Sub
	<TestMethod()> _
	Public Sub test1400000()
		Assert.AreEqual("2 1/2 42ND ST", t("2 1/2 42 ST."))
	End Sub
	<TestMethod()> _
	Public Sub test1500000()
		Assert.AreEqual("3 2ND ST", t("3 2 ST."))
	End Sub
	<TestMethod()> _
	Public Sub test1800000()
		Assert.AreEqual("1 MID ISLAND PLZ", t("1 MID-ISLAND PLaza"))
	End Sub
	<TestMethod()> _
	Public Sub test1900000()
		Assert.AreEqual("289-01 MONTGOMERY AVE", t("289-01 MONTGOMERY AVEnue"))
	End Sub
	<TestMethod()> _
	Public Sub test2000000()
		Assert.AreEqual("1 MID ISLAND PLZ APT 36D", t("1 MID-ISLAND PLaza APT 36-D"))
	End Sub
	<TestMethod()> _
	Public Sub test2100000()
		Assert.AreEqual("1 MID ISLAND PLZ APT D36", t("1 MID-ISLAND PLaza APT D-36"))
	End Sub
	<TestMethod()> _
	Public Sub test2200000()
		Assert.AreEqual("1 1/2 MID ISLAND PLZ APT D36", t("1 1/2 MID-ISLAND PLaza APT D-36"))
	End Sub
	<TestMethod()> _
	Public Sub test3000000()
		Assert.AreEqual("1 7TH AVE STE 33", t("1 7 av /suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test3100000()
		Assert.AreEqual("1 7TH AVE STE 33", t("1 7 av -- suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test3200000()
		Assert.AreEqual("1 7TH AVE STE 33", t("1 7 av - suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test3300000()
		Assert.AreEqual("1 7TH AVE # 33", t("1 7 av - #33"))
	End Sub
	<TestMethod()> _
	Public Sub test3400000()
		Assert.AreEqual("1 7TH AVE APT 33", t("1 7 av /APT#33"))
	End Sub
	<TestMethod()> _
	Public Sub test3500000()
		Assert.AreEqual("1 7TH AVE APT 33", t("1 7 av / APT#33"))
	End Sub
	<TestMethod()> _
	Public Sub test3700000()
		Assert.AreEqual("1 N BAY ST", t("1 NORTH BAY ST"))
	End Sub
	<TestMethod()> _
	Public Sub test3800000()
		Assert.AreEqual("1 E END AVE", t("1 EAST END AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test3900000()
		Assert.AreEqual("1 BAY DR W", t("1 BAY DRIVE WEST"))
	End Sub
	<TestMethod()> _
	Public Sub test4100000()
		Assert.AreEqual("1 N SOUTH OAK ST", t("1 NORTH SOUTH OAK ST"))
	End Sub
	<TestMethod()> _
	Public Sub test4200000()
		Assert.AreEqual("2 1/2 N SOUTH OAK ST FL 8", t("2 1/2 NORTH SOUTH OAK ST 8fl"))
	End Sub
	<TestMethod()> _
	Public Sub test4300000()
		Assert.AreEqual("3 NE MAIN ST", t("3 NORTH EAST MAIN ST"))
	End Sub
	<TestMethod()> _
	Public Sub test4400000()
		Assert.AreEqual("1 1/2 NE MAIN ST", t("1 1/2 NORTH EAST MAIN ST"))
	End Sub
	<TestMethod()> _
	Public Sub test4500000()
		Assert.AreEqual("1 MAPLE COURT EAST W", t("1 MAPLE CourT EAST WEST"))
	End Sub
	<TestMethod()> _
	Public Sub test4600000()
		Assert.AreEqual("9 MAPLE COURT EAST W OFC A", t("9 MAPLE CourT EAST WEST ofc a"))
	End Sub
	<TestMethod()> _
	Public Sub test4700000()
		Assert.AreEqual("1 BAY AVE SW", t("1 BAY AVE SOUTHWEST"))
	End Sub
	<TestMethod()> _
	Public Sub test4800000()
		Assert.AreEqual("2 BAY AVE SW APT 99", t("2 BAY AVE SOUTHWEST apt. 99"))
	End Sub
	<TestMethod()> _
	Public Sub test4900000()
		Assert.AreEqual("1 COUNTY ROAD N E", t("1 COUNTY ROAD N EAST"))
	End Sub
	<TestMethod()> _
	Public Sub test5000000()
		Assert.AreEqual("1 COUNTY ROAD N E", t("1 COUNTY RD N EAST"))
	End Sub
	<TestMethod()> _
	Public Sub test5100000()
		Assert.AreEqual("1 COUNTY ROAD N E FL 13", t("1 COUNTY RD N EAST floor 13"))
	End Sub
	<TestMethod()> _
	Public Sub test5400000()
		Assert.AreEqual("1 FOGEL AVE", t("1 FOGEL AVEnue"))
	End Sub
	<TestMethod()> _
	Public Sub test5500000()
		Assert.AreEqual("1 1/2 FOGEL AVE", t("1 1/2 FOGEL AVEnue"))
	End Sub
	<TestMethod()> _
	Public Sub test5600000()
		Assert.AreEqual("1 1/2 FOGEL AVE STE 33", t("1 1/2 FOGEL AVEnue suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test6000000()
		Assert.AreEqual("1000 AVENUE E", t("1000 AVENUE E"))
	End Sub
	<TestMethod()> _
	Public Sub test6100000()
		Assert.AreEqual("103 AVENUE E", t("103 AVE E"))
	End Sub
	<TestMethod()> _
	Public Sub test6200000()
		Assert.AreEqual("103 1/2 AVENUE E", t("103 1/2 AVE E"))
	End Sub
	<TestMethod()> _
	Public Sub test6300000()
		Assert.AreEqual("1000 AVENUE E", t("1000 AV E"))
	End Sub
	<TestMethod()> _
	Public Sub test6400000()
		Assert.AreEqual("1000 1/2 AVENUE E", t("1000 1/2 AV E"))
	End Sub
	<TestMethod()> _
	Public Sub test6500000()
		Assert.AreEqual("10 AVENUE E FL 10", t("10 AV E 10 fl"))
	End Sub
	<TestMethod()> _
	Public Sub test6600000()
		Assert.AreEqual("300 AVENUE E # 10", t("300 AV E #10"))
	End Sub
	<TestMethod()> _
	Public Sub test6700000()
		Assert.AreEqual("300 1/2 AVENUE E # 10", t("300 1/2 AV E #10"))
	End Sub
	<TestMethod()> _
	Public Sub test6800000()
		Assert.AreEqual("2 COURT ST", t("Two Court St"))
	End Sub
	<TestMethod()> _
	Public Sub test7000000()
		Assert.AreEqual("1 RANCH ROAD 620", t("1 RANCH RD 620"))
	End Sub
	<TestMethod()> _
	Public Sub test7100000()
		Assert.AreEqual("1 RANCH ROAD 620", t("1 RANCH RD #620"))
	End Sub
	<TestMethod()> _
	Public Sub test7200000()
		Assert.AreEqual("1 RANCH ROAD 620", t("1 RANCH RD no 620"))
	End Sub
	<TestMethod()> _
	Public Sub test7300000()
		Assert.AreEqual("1 RANCH ROAD 620X", t("1 RANCH RD 620X"))
	End Sub
	<TestMethod()> _
	Public Sub test7400000()
		Assert.AreEqual("1 RANCH ROAD 620X # 55", t("1 RANCH RD 620X #55"))
	End Sub
	<TestMethod()> _
	Public Sub test7500000()
		Assert.AreEqual("1 RANCH ROAD 620Y STE 9", t("1 RANCH RD 620Y suite 9"))
	End Sub
	<TestMethod()> _
	Public Sub test7600000()
		Assert.AreEqual("1 1/2 RANCH ROAD 620X", t("1 1/2 RANCH RD 620X"))
	End Sub
	<TestMethod()> _
	Public Sub test7700000()
		Assert.AreEqual("1 RANCH ROAD 620X", t("1 RANCH RD #620X"))
	End Sub
	<TestMethod()> _
	Public Sub test7800000()
		Assert.AreEqual("1 RANCH ROAD 620X", t("1 RANCH RD no. 620X"))
	End Sub
	<TestMethod()> _
	Public Sub test7900000()
		Assert.AreEqual("1 RANCH ROAD 620 W APT 33", t("1 RANCH RD 620 west apt 33"))
	End Sub
	<TestMethod()> _
	Public Sub test8000000()
		Assert.AreEqual("1 BRANCH RD # 620", t("1 BRANCH RD #620"))
	End Sub
	<TestMethod()> _
	Public Sub test8100000()
		Assert.AreEqual("1 RANCH RD APT 2", t("1 RANCH Road apt 2"))
	End Sub
	<TestMethod()> _
	Public Sub test8200000()
		Assert.AreEqual("5 RANCH RD APT 3", t("5 RANCH Road apt #3"))
	End Sub
	<TestMethod()> _
	Public Sub test8600000()
		Assert.AreEqual("RR 2 BOX 152", t("RR 2 BOX 152"))
	End Sub
	<TestMethod()> _
	Public Sub test8610000()
		Assert.AreEqual("RR 1 BOX 218", t("Box 218 RR 1"))
	End Sub
	<TestMethod()> _
	Public Sub test8620000()
		Assert.AreEqual("RR 1 BOX 218", t("Box 218 RR 1 SMITHFIELD FARM"))
	End Sub
	<TestMethod()> _
	Public Sub test8700000()
		Assert.AreEqual("RR 2 BOX 152", t("Rural Route 2 BOX 152"))
	End Sub
	<TestMethod()> _
	Public Sub test8710000()
		Assert.AreEqual("RR 2 BOX 152", t("Rural Rte 2 BOX 152"))
	End Sub
	<TestMethod()> _
	Public Sub test8800000()
		Assert.AreEqual("RR 4 BOX 87A", t("RFD ROUTE 4 #87A"))
	End Sub
	<TestMethod()> _
	Public Sub test8900000()
		Assert.AreEqual("RR 4 BOX 87A", t("RD ROUTE 4 #87A"))
	End Sub
	<TestMethod()> _
	Public Sub test8910000()
		Assert.AreEqual("RR 4 BOX 87A", t("RD RT 4 #87A"))
	End Sub
	<TestMethod()> _
	Public Sub test9000000()
		Assert.AreEqual("RR 2 BOX 18", t("RR 2 BOX 18 BRYAN DAIRY RD"))
	End Sub
	<TestMethod()> _
	Public Sub test9200000()
		Assert.AreEqual("1 COUNTY HIGHWAY 140 FL 10", t("1 COUNTY HIGHWAY 140 10floor"))
	End Sub
	<TestMethod()> _
	Public Sub test9300000()
		Assert.AreEqual("2 COUNTY HWY RM 62", t("2 COUNTY HIGHWAY room 62"))
	End Sub
	<TestMethod()> _
	Public Sub test9400000()
		Assert.AreEqual("3 COUNTY HWY RM 63", t("3 COUNTY HIGHWAY room #63"))
	End Sub
	<TestMethod()> _
	Public Sub test9500000()
		Assert.AreEqual("4 1/2 COUNTY HWY RM 64", t("4 1/2 COUNTY HIGHWAY room # 64"))
	End Sub
	<TestMethod()> _
	Public Sub test9600000()
		Assert.AreEqual("2 COUNTY HIGHWAY 120 FL 10", t("2 COUNTY HIGHWAY 120 floor 10"))
	End Sub
	<TestMethod()> _
	Public Sub test9700000()
		Assert.AreEqual("3 COUNTY HIGHWAY 130 FL 10", t("3 COUNTY HIGHWAY 130 10 fl"))
	End Sub
	<TestMethod()> _
	Public Sub test9800000()
		Assert.AreEqual("3 COUNTY HIGHWAY 130 # 10", t("3 COUNTY HIGHWAY 130 #10"))
	End Sub
	<TestMethod()> _
	Public Sub test9900000()
		Assert.AreEqual("3 COUNTY HIGHWAY 130 RM 10", t("3 COUNTY HIGHWAY 130 room #10"))
	End Sub
	<TestMethod()> _
	Public Sub test10100000()
		Assert.AreEqual("4 COUNTY HIGHWAY 120 E FL 10", t("4 COUNTY HIGHWAY 120 east floor 10"))
	End Sub
	<TestMethod()> _
	Public Sub test10200000()
		Assert.AreEqual("1 COUNTY HIGHWAY 60E", t("1 COUNTY HWY 60E"))
	End Sub
	<TestMethod()> _
	Public Sub test10300000()
		Assert.AreEqual("4 COUNTY HIGHWAY 60W", t("4 COUNTY HWY #60W"))
	End Sub
	<TestMethod()> _
	Public Sub test10400000()
		Assert.AreEqual("4 COUNTY HIGHWAY 50S", t("4 COUNTY HWY no. 50S"))
	End Sub
	<TestMethod()> _
	Public Sub test10500000()
		Assert.AreEqual("1 WV COUNTY HIGHWAY 60E", t("1 west virginia COUNTY HWY 60E"))
	End Sub
	<TestMethod()> _
	Public Sub test10600000()
		Assert.AreEqual("1 CT COUNTY HIGHWAY 60E", t("1 Connecticut County Hwy 60E"))
	End Sub
	<TestMethod()> _
	Public Sub test10601000()
		Assert.AreEqual("1 CT COUNTY HIGHWAY 60E", t("1 CT County Hwy 60E"))
	End Sub
	<TestMethod()> _
	Public Sub test10700000()
		Assert.AreEqual("1 BLUE COUNTY HIGHWAY 60E", t("1 blue COUNTY HWY 60E"))
	End Sub
	<TestMethod()> _
	Public Sub test10800000()
		Assert.AreEqual("1 COUNTY HIGHWAY 20", t("1 CNTY HWY 20"))
	End Sub
	<TestMethod()> _
	Public Sub test10900000()
		Assert.AreEqual("22 COUNTY HIGHWAY 20 STE 33", t("22 CNTY HWY 20 Suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test11000000()
		Assert.AreEqual("4A COUNTY HIGHWAY 20 STE 33", t("4A CNTY HWY 20 Suite #33"))
	End Sub
	<TestMethod()> _
	Public Sub test11100000()
		Assert.AreEqual("55-32 COUNTY HIGHWAY 20A E APT 33", t("55-32 CNTY HWY 20A East apt. 33"))
	End Sub
	<TestMethod()> _
	Public Sub test11200000()
		Assert.AreEqual("1 COUNTY HIGHWAY 9W", t("One CNTY HWY 9W"))
	End Sub
	<TestMethod()> _
	Public Sub test11300000()
		Assert.AreEqual("33 1/2 COUNTY HIGHWAY 9", t("33 1/2 CNTY HWY 9"))
	End Sub
	<TestMethod()> _
	Public Sub test11700000()
		Assert.AreEqual("15523 DAWN CRST", t("15523 Dawn Crest"))
	End Sub
	<TestMethod()> _
	Public Sub test11800000()
		Assert.AreEqual("1 COUNTY ROAD 110", t("1 COUNTY ROAD 110"))
	End Sub
	<TestMethod()> _
	Public Sub test11900000()
		Assert.AreEqual("1 COUNTY RD STE 110", t("1 COUNTY ROAD suite 110"))
	End Sub
	<TestMethod()> _
	Public Sub test12000000()
		Assert.AreEqual("1 COUNTY RD STE 110", t("1 COUNTY ROAD suite #110"))
	End Sub
	<TestMethod()> _
	Public Sub test12100000()
		Assert.AreEqual("1 COUNTY ROAD 441", t("1 COUNTY RD 441"))
	End Sub
	<TestMethod()> _
	Public Sub test12200000()
		Assert.AreEqual("1 COUNTY ROAD 441", t("1 COUNTY RD #441"))
	End Sub
	<TestMethod()> _
	Public Sub test12300000()
		Assert.AreEqual("1 COUNTY ROAD 441", t("1 COUNTY RD no 441"))
	End Sub
	<TestMethod()> _
	Public Sub test12400000()
		Assert.AreEqual("1 1/2 COUNTY ROAD 441", t("1 1/2 COUNTY RD 441"))
	End Sub
	<TestMethod()> _
	Public Sub test12500000()
		Assert.AreEqual("1 COUNTY ROAD 1185", t("1 CR 1185"))
	End Sub
	<TestMethod()> _
	Public Sub test12600000()
		Assert.AreEqual("1 COUNTY ROAD 33", t("1 CNTY RD 33"))
	End Sub
	<TestMethod()> _
	Public Sub test12700000()
		Assert.AreEqual("1 COUNTY ROAD 33 FL 8", t("1 CNTY RD 33 8 FL"))
	End Sub
	<TestMethod()> _
	Public Sub test12800000()
		Assert.AreEqual("1 CA COUNTY ROAD 150", t("1 CA COUNTY RD 150"))
	End Sub
	<TestMethod()> _
	Public Sub test12900000()
		Assert.AreEqual("1 CA COUNTY ROAD X APT 150", t("1 CA COUNTY RD X apt 150"))
	End Sub
	<TestMethod()> _
	Public Sub test13000000()
		Assert.AreEqual("1 CA COUNTY ROAD X # 150", t("1 CA COUNTY RD X #150"))
	End Sub
	<TestMethod()> _
	Public Sub test13100000()
		Assert.AreEqual("1 CA COUNTY ROAD 2 # 150", t("1 CA COUNTY RD 2 #150"))
	End Sub
	<TestMethod()> _
	Public Sub test13200000()
		Assert.AreEqual("1 CA COUNTY ROAD X APT 150", t("1 CA COUNTY RD X apt #150"))
	End Sub
	<TestMethod()> _
	Public Sub test13300000()
		Assert.AreEqual("1 CA COUNTY ROAD 555", t("1 CALIFORNIA COUNTY ROAD 555"))
	End Sub
	<TestMethod()> _
	Public Sub test13400000()
		Assert.AreEqual("1 3/4 CA COUNTY ROAD 555", t("1 3/4 CALIFORNIA COUNTY ROAD 555"))
	End Sub
	<TestMethod()> _
	Public Sub test13700000()
		Assert.AreEqual("1 COUNTY ROAD N E", t("1 COUNTY ROAD N EAST"))
	End Sub
	<TestMethod()> _
	Public Sub test13800000()
		Assert.AreEqual("1 COUNTY ROAD N E", t("1 COUNTY RD N EAST"))
	End Sub
	<TestMethod()> _
	Public Sub test13900000()
		Assert.AreEqual("5 5/8 COUNTY ROAD N E", t("5 5/8 COUNTY RD N EAST"))
	End Sub
	<TestMethod()> _
	Public Sub test14000000()
		Assert.AreEqual("1 COUNTY ROAD N E FL 13", t("1 COUNTY RD N EAST floor 13"))
	End Sub
	<TestMethod()> _
	Public Sub test14100000()
		Assert.AreEqual("1 MI COUNTY ROAD N E FL 13", t("1 michigan COUNTY RD N EAST floor 13"))
	End Sub
	<TestMethod()> _
	Public Sub test14200000()
		Assert.AreEqual("1 9/9 COUNTY ROAD N E FL 13", t("1 9/9 COUNTY RD N EAST floor 13"))
	End Sub
	<TestMethod()> _
	Public Sub test14500000()
		Assert.AreEqual("1 STATE ROAD 220", t("1 SR 220"))
	End Sub
	<TestMethod()> _
	Public Sub test14600000()
		Assert.AreEqual("1 STATE ROAD 55", t("1 STATE ROAD 55"))
	End Sub
	<TestMethod()> _
	Public Sub test14700000()
		Assert.AreEqual("1 STATE ROAD 86", t("1 ST RD 86"))
	End Sub
	<TestMethod()> _
	Public Sub test14800000()
		Assert.AreEqual("1 NY STATE ROAD 86", t("1 New York SR #86"))
	End Sub
	<TestMethod()> _
	Public Sub test14900000()
		Assert.AreEqual("1 NJ STATE ROAD 86", t("1 New Jersey ST RD 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15000000()
		Assert.AreEqual("5 NJ STATE RD APT 86", t("5 New Jersey ST RD apt 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15100000()
		Assert.AreEqual("1 NJ STATE ROAD 86 RM 89", t("1 New Jersey ST RD 86 room 89"))
	End Sub
	<TestMethod()> _
	Public Sub test15110000()
		Assert.AreEqual("1 FL STATE ROAD 86", t("1 Florida ST RD 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15111000()
		Assert.AreEqual("1 FL STATE ROAD 86", t("1 FL state Road 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15112000()
		Assert.AreEqual("1 FL STATE ROAD 86", t("1 FL ST RD 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15120000()
		Assert.AreEqual("1 CT STATE ROAD 86", t("1 Connecticut ST RD 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15121000()
		Assert.AreEqual("1 CT STATE ROAD 86", t("1 CT state Road 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15122000()
		Assert.AreEqual("1 CT STATE ROAD 86", t("1 CT ST RD 86"))
	End Sub
	<TestMethod()> _
	Public Sub test15200000()
		Assert.AreEqual("1 1/2 NJ STATE ROAD 86 RM 89", t("1 1/2 New Jersey ST RD 86 room 89"))
	End Sub
	<TestMethod()> _
	Public Sub test15300000()
		Assert.AreEqual("1 MS STATE ROAD 86 W FL 34", t("1 MS ST RD 86 W 34 FLOOR"))
	End Sub
	<TestMethod()> _
	Public Sub test15600000()
		Assert.AreEqual("1 STATE ROUTE 260", t("1 STATE RouTE 260"))
	End Sub
	<TestMethod()> _
	Public Sub test15700000()
		Assert.AreEqual("1 STATE ROUTE 175", t("1 ST RT 175"))
	End Sub
	<TestMethod()> _
	Public Sub test15800000()
		Assert.AreEqual("1 OR STATE ROUTE 175", t("1 OR ST RT 175"))
	End Sub
	<TestMethod()> _
	Public Sub test15900000()
		Assert.AreEqual("1 1/3 OR STATE ROUTE 175", t("1 1/3 ORegon ST RT 175"))
	End Sub
	<TestMethod()> _
	Public Sub test16000000()
		Assert.AreEqual("1 STATE ROUTE 17", t("1 ST ROUTE 17"))
	End Sub
	<TestMethod()> _
	Public Sub test16023000()
		Assert.AreEqual("1 STATE ROUTE 260 STE 33", t("1 STATE RouTE 260 suite #33"))
	End Sub
	<TestMethod()> _
	Public Sub test16024000()
		Assert.AreEqual("1 STATE ROUTE 260 STE 33", t("1 STATE RouTE 260 /suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test16025000()
		Assert.AreEqual("1 STATE ROUTE 260 STE 33", t("1 STATE RouTE 260 -- suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test16026000()
		Assert.AreEqual("1 STATE ROUTE 260 STE 33", t("1 STATE RouTE 260 - suite 33"))
	End Sub
	<TestMethod()> _
	Public Sub test16027000()
		Assert.AreEqual("1 STATE ROUTE 260 # 33", t("1 STATE RouTE 260 - #33"))
	End Sub
	<TestMethod()> _
	Public Sub test16028000()
		Assert.AreEqual("1 STATE ROUTE 260 APT 33", t("1 STATE RouTE 260 /APT#33"))
	End Sub
	<TestMethod()> _
	Public Sub test16029000()
		Assert.AreEqual("1 STATE ROUTE 260 APT 33", t("1 STATE RouTE 260 / APT#33"))
	End Sub
	<TestMethod()> _
	Public Sub test16100000()
		Assert.AreEqual("1 STATE ROUTE 22", t("1 ST Rte 22"))
	End Sub
	<TestMethod()> _
	Public Sub test16200000()
		Assert.AreEqual("1 STATE ROUTE 22", t("1 ST Rte #22"))
	End Sub
	<TestMethod()> _
	Public Sub test16300000()
		Assert.AreEqual("1 STATE ROUTE 22", t("1 ST Rte no 22"))
	End Sub
	<TestMethod()> _
	Public Sub test16400000()
		Assert.AreEqual("1 STATE RTE APT 22", t("1 ST Rte apartment 22"))
	End Sub
	<TestMethod()> _
	Public Sub test16500000()
		Assert.AreEqual("1 STATE ROUTE 260 E RM 33", t("1 STATE RTE 260 east room #33"))
	End Sub
	<TestMethod()> _
	Public Sub test16600000()
		Assert.AreEqual("1 3/5 STATE ROUTE 260 E RM 33", t("1 3/5 STATE RTE 260 east room #33"))
	End Sub
	<TestMethod()> _
	Public Sub test17000000()
		Assert.AreEqual("1 INTERSTATE 10", t("1 I10"))
	End Sub
	<TestMethod()> _
	Public Sub test17100000()
		Assert.AreEqual("1 INTERSTATE 40", t("1 INTERSTATE 40"))
	End Sub
	<TestMethod()> _
	Public Sub test17200000()
		Assert.AreEqual("1 INTERSTATE 280", t("1 IH280"))
	End Sub
	<TestMethod()> _
	Public Sub test17300000()
		Assert.AreEqual("1 INTERSTATE 680", t("1 INTERSTATE HWY 680"))
	End Sub
	<TestMethod()> _
	Public Sub test17400000()
		Assert.AreEqual("1 1/2 INTERSTATE 680", t("1 1/2 INTERSTATE HWY 680"))
	End Sub
	<TestMethod()> _
	Public Sub test17500000()
		Assert.AreEqual("1 INTERSTATE 55 BYP", t("1 I 55 BYPASS"))
	End Sub
	<TestMethod()> _
	Public Sub test17600000()
		Assert.AreEqual("1 INTERSTATE 26 BYPASS RD", t("1 I 26 BYP ROAD"))
	End Sub
	<TestMethod()> _
	Public Sub test17700000()
		Assert.AreEqual("1 INTERSTATE 26 BYPASS RD", t("1 I 26 BYPASS ROAD"))
	End Sub
	<TestMethod()> _
	Public Sub test17800000()
		Assert.AreEqual("1 INTERSTATE 44 FRONTAGE RD", t("1 I 44 FRONTAGE ROAD"))
	End Sub
	<TestMethod()> _
	Public Sub test17900000()
		Assert.AreEqual("1 INTERSTATE 44 FRONTAGE RD STE 4", t("1 I 44 FRONTAGE ROAD suite 4"))
	End Sub
	<TestMethod()> _
	Public Sub test18000000()
		Assert.AreEqual("55 1/5 INTERSTATE 44 FRONTAGE RD STE 4", t("55 1/5 I 44 FRONTAGE ROAD suite 4"))
	End Sub
	<TestMethod()> _
	Public Sub test18300000()
		Assert.AreEqual("1 STATE HIGHWAY 303", t("1 ST HIGHWAY 303"))
	End Sub
	<TestMethod()> _
	Public Sub test18400000()
		Assert.AreEqual("1 MI STATE HIGHWAY 303", t("1 Michigan ST HIGHWAY 303"))
	End Sub
	<TestMethod()> _
	Public Sub test18500000()
		Assert.AreEqual("1 MI STATE HIGHWAY 303 # 405", t("1 Michigan ST HIGHWAY 303 #405"))
	End Sub
	<TestMethod()> _
	Public Sub test18600000()
		Assert.AreEqual("1 MI STATE HIGHWAY 303", t("1 Michigan STATE HIGHWAY #303"))
	End Sub
	<TestMethod()> _
	Public Sub test18700000()
		Assert.AreEqual("1 STATE HWY RM 303", t("1 ST HIGHWAY rm 303"))
	End Sub
	<TestMethod()> _
	Public Sub test18800000()
		Assert.AreEqual("1 MD STATE HWY RM 303", t("1 Maryland ST HIGHWAY rm 303"))
	End Sub
	<TestMethod()> _
	Public Sub test18900000()
		Assert.AreEqual("1 STATE HIGHWAY 60", t("1 STATE HWY 60"))
	End Sub
	<TestMethod()> _
	Public Sub test19000000()
		Assert.AreEqual("2 1/2 STATE HWY RM 303", t("2 1/2 ST HIGHWAY rm 303"))
	End Sub
	<TestMethod()> _
	Public Sub test19100000()
		Assert.AreEqual("3 1/4 STATE HIGHWAY 60", t("3 1/4 STATE HWY 60"))
	End Sub
	<TestMethod()> _
	Public Sub test19300000()
		Assert.AreEqual("3 1/4 STATE HIGHWAY 60 E", t("3 1/4 STATE HWY 60 E"))
	End Sub
	<TestMethod()> _
	Public Sub test19500000()
		Assert.AreEqual("1 ROAD 5A", t("1 RD 5A"))
	End Sub
	<TestMethod()> _
	Public Sub test19600000()
		Assert.AreEqual("1 ROAD 22", t("1 ROAD 22"))
	End Sub
	<TestMethod()> _
	Public Sub test19700000()
		Assert.AreEqual("1 7TH RD # 22", t("1 7 ROAD # 22"))
	End Sub
	<TestMethod()> _
	Public Sub test19800000()
		Assert.AreEqual("1 8TH RD APT 22", t("1 8 ROAD apt 22"))
	End Sub
	<TestMethod()> _
	Public Sub test19900000()
		Assert.AreEqual("1 1/2 ROAD 22", t("1 1/2 ROAD 22"))
	End Sub
	<TestMethod()> _
	Public Sub test20000000()
		Assert.AreEqual("1 ROAD 112 APT 8", t("1 ROAD 112 apt. 8"))
	End Sub
	<TestMethod()> _
	Public Sub test20100000()
		Assert.AreEqual("3 ROAD 22 APT 10", t("3 ROAD 22 apt. #10"))
	End Sub
	<TestMethod()> _
	Public Sub test20200000()
		Assert.AreEqual("5 ROAD 235 # 6", t("5 ROAD 235 #6"))
	End Sub
	<TestMethod()> _
	Public Sub test20600000()
		Assert.AreEqual("1 ROUTE 88", t("1 RT 88"))
	End Sub
	<TestMethod()> _
	Public Sub test20700000()
		Assert.AreEqual("1 ROUTE 95", t("1 RTE 95"))
	End Sub
	<TestMethod()> _
	Public Sub test20800000()
		Assert.AreEqual("1 ROUTE 1150EE", t("1 ROUTE 1150EE"))
	End Sub
	<TestMethod()> _
	Public Sub test20900000()
		Assert.AreEqual("1 ROUTE 1150EE STE 55", t("1 ROUTE 1150EE suite 55"))
	End Sub
	<TestMethod()> _
	Public Sub test21000000()
		Assert.AreEqual("1 1/2 ROUTE 1150EE STE 55", t("1 1/2 ROUTE 1150EE suite 55"))
	End Sub
	<TestMethod()> _
	Public Sub test21300000()
		Assert.AreEqual("941 BOULEVARD E APT 5B", t("941 Boulevard East APT 5B"))
	End Sub
	<TestMethod()> _
	Public Sub test21400000()
		Assert.AreEqual("941 BOULEVARD E APT 5B", t("941 Blvd E APT 5B"))
	End Sub
	<TestMethod()> _
	Public Sub test21700000()
		Assert.AreEqual("123 AVENUE B", t("123 AVENUE B"))
	End Sub
	<TestMethod()> _
	Public Sub test21800000()
		Assert.AreEqual("123 AVENUE B", t("123 AVE B"))
	End Sub
	<TestMethod()> _
	Public Sub test21900000()
		Assert.AreEqual("123 AVENUE B # 3", t("123 AVE B #3"))
	End Sub
	<TestMethod()> _
	Public Sub test22000000()
		Assert.AreEqual("123 AVENUE B APT 3", t("123 AVE B APARTMENT 3"))
	End Sub
	<TestMethod()> _
	Public Sub test22200000()
		Assert.AreEqual("PO BOX 9", t("POB 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22252000()
		Assert.AreEqual("PO BOX 9", t("P. O. B. 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22260000()
		Assert.AreEqual("PO BOX 9", t("P O Box 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22261000()
		Assert.AreEqual("PO BOX 9", t("P. O. Box 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22263000()
		Assert.AreEqual("PO BOX 9", t("P.O. Box 9, 100 Powers Blvd"))
	End Sub
	<TestMethod()> _
	Public Sub test22265000()
		Assert.AreEqual("PO BOX 9", t("P.O.Box 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22266000()
		Assert.AreEqual("PO BOX 9", t("POBox 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22267000()
		Assert.AreEqual("PO BOX 9", t("PO BOX 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22268000()
		Assert.AreEqual("PO BOX 9", t("P.O. BOX 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22269000()
		Assert.AreEqual("PO BOX 9", t("P.O.B. 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22270000()
		Assert.AreEqual("PO BOX 9", t("P O B 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22273000()
		Assert.AreEqual("PO BOX 9", t("POST OFFICE BOX 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22274000()
		Assert.AreEqual("PO BOX 9", t("POST OFFICE BX 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22275000()
		Assert.AreEqual("PO BOX 9", t("POB #9"))
	End Sub
	<TestMethod()> _
	Public Sub test22276000()
		Assert.AreEqual("PO BOX 9", t("P.O. BOX #9"))
	End Sub
	<TestMethod()> _
	Public Sub test22277000()
		Assert.AreEqual("PO BOX 9", t("P.O. BX. 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22278000()
		Assert.AreEqual("PO BOX 9", t("PO BX 9"))
	End Sub
	<TestMethod()> _
	Public Sub test22300000()
		Assert.AreEqual("PO BOX 12", t("CALLER 12"))
	End Sub
	<TestMethod()> _
	Public Sub test22400000()
		Assert.AreEqual("PO BOX 35", t("BIN 35"))
	End Sub
	<TestMethod()> _
	Public Sub test22500000()
		Assert.AreEqual("PO BOX 123", t("LOCKBOX 123"))
	End Sub
	<TestMethod()> _
	Public Sub test22600000()
		Assert.AreEqual("PO BOX 77", t("DRAWER 77"))
	End Sub
	<TestMethod()> _
	Public Sub test22700000()
		Assert.AreEqual("PO BOX 987", t("PO BOX 987"))
	End Sub
	<TestMethod()> _
	Public Sub test22710000()
		Assert.AreEqual("PO BOX 268", t("PO 268, Radio City Sta."))
	End Sub
	<TestMethod()> _
	Public Sub test22720000()
		Assert.AreEqual("PO BOX 268", t("BOX 268"))
	End Sub
	<TestMethod()> _
	Public Sub test22800000()
		Assert.AreEqual("PO BOX A", t("CALLER A"))
	End Sub
	<TestMethod()> _
	Public Sub test22900000()
		Assert.AreEqual("PO BOX E", t("BIN E"))
	End Sub
	<TestMethod()> _
	Public Sub test23000000()
		Assert.AreEqual("PO BOX A", t("LOCKBOX A"))
	End Sub
	<TestMethod()> _
	Public Sub test23100000()
		Assert.AreEqual("PO BOX B", t("DRAWER B"))
	End Sub
	<TestMethod()> _
	Public Sub test23200000()
		Assert.AreEqual("PO BOX C", t("PO BOX C"))
	End Sub
	<TestMethod()> _
	Public Sub test23300000()
		Assert.AreEqual("PO BOX B", t("POB B"))
	End Sub
	<TestMethod()> _
	Public Sub test23400000()
		Assert.AreEqual("PO BOX 34", t("FIRM CALLER 34"))
	End Sub
	<TestMethod()> _
	Public Sub test23500000()
		Assert.AreEqual("PO BOX L", t("FIRM CALLER L"))
	End Sub
	<TestMethod()> _
	Public Sub test23700000()
		Assert.AreEqual("PO BOX 9", t("POB ##9"))
	End Sub
	<TestMethod()> _
	Public Sub test24000000()
		Assert.AreEqual("101 MAIN ST", t("101 MAIN STreet"))
	End Sub
	<TestMethod()> _
	Public Sub test24100000()
		Assert.AreEqual("101 MAIN ST APT 12", t("101 MAIN STreet APartmenT 12"))
	End Sub
	<TestMethod()> _
	Public Sub test24200000()
		Assert.AreEqual("101 W MAIN ST APT 12", t("101 West MAIN STreet APT 12"))
	End Sub
	<TestMethod()> _
	Public Sub test24300000()
		Assert.AreEqual("101 W MAIN ST S APT 12", t("101 West MAIN STreet South APT 12"))
	End Sub
	<TestMethod()> _
	Public Sub test24400000()
		Assert.AreEqual("411 N RIDGEWOOD RD", t("411 North Ridgewood Road"))
	End Sub
	<TestMethod()> _
	Public Sub test24401000()
		Assert.AreEqual("411 N RIDGEWOOD RD", t("411 N Ridgewood Road"))
	End Sub
	<TestMethod()> _
	Public Sub test24405000()
		Assert.AreEqual("1 NORTH AVE", t("1 NORTH AVEnue"))
	End Sub
	<TestMethod()> _
	Public Sub test24406000()
		Assert.AreEqual("1 NORTH AVE", t("1 N Avenue"))
	End Sub
	<TestMethod()> _
	Public Sub test24410000()
		Assert.AreEqual("39 N MOUNTAIN AVE", t("39 NORTH MOUNTAIN AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test24411000()
		Assert.AreEqual("39 N MOUNTAIN AVE", t("39 N MOUNTAIN AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test24412000()
		Assert.AreEqual("39 MOUNTAIN AVE N", t("39 MOUNTAIN AVE NORTH"))
	End Sub
	<TestMethod()> _
	Public Sub test24413000()
		Assert.AreEqual("39 MOUNTAIN AVE N", t("39 MOUNTAIN AVE N"))
	End Sub
	<TestMethod()> _
	Public Sub test24415000()
		Assert.AreEqual("1 SOUTHEAST FWY N", t("1 SOUTHEAST FREEWAY NORTH"))
	End Sub
	<TestMethod()> _
	Public Sub test24416000()
		Assert.AreEqual("1 SOUTHEAST FWY N", t("1 SE FREEWAY NORTH"))
	End Sub
	<TestMethod()> _
	Public Sub test24419000()
		Assert.AreEqual("1 BAY WEST DR", t("1 BAY WEST DRive"))
	End Sub
	<TestMethod()> _
	Public Sub test24420000()
		Assert.AreEqual("110 E END AVE", t("110 EAST END AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test24425000()
		Assert.AreEqual("110 E END AVE", t("110 E END AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test24430000()
		Assert.AreEqual("184 UPPER MOUNTAIN AVE", t("184 UPPR MOUNTAIN AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test24440000()
		Assert.AreEqual("184 UPPER MOUNTAIN AVE", t("184 UPPER MOUNTAIN AVE"))
	End Sub
	<TestMethod()> _
	Public Sub test24450000()
		Assert.AreEqual("184 UPPER LAVALA ST", t("184 UPPER LAVALA street"))
	End Sub
	<TestMethod()> _
	Public Sub test24460000()
		Assert.AreEqual("184 UPPER LAVALA ST", t("184 UPPR LAVALA street"))
	End Sub
	<TestMethod()> _
	Public Sub test24500000()
		Assert.AreEqual("4015 7TH AVE", t("4015 Seventh Avenue"))
	End Sub
	<TestMethod()> _
	Public Sub test24600000()
		Assert.AreEqual("4015 7TH AVE", t("4015 7 Avenue"))
	End Sub
	<TestMethod()> _
	Public Sub test24700000()
		Assert.AreEqual("4015 1/2 7TH AVE", t("4015 1/2 7 Avenue"))
	End Sub
	<TestMethod()> _
	Public Sub test24800000()
		Assert.AreEqual("4015 7TH AVE", t("4015 7th Avenue"))
	End Sub
	<TestMethod()> _
	Public Sub test24900000()
		Assert.AreEqual("4015 7TH AVE", t("4015 7th Ave"))
	End Sub
	<TestMethod()> _
	Public Sub test25000000()
		Assert.AreEqual("4015 7TH AVE APT 4", t("4015 7th Avenue apt 4"))
	End Sub
	<TestMethod()> _
	Public Sub test25100000()
		Assert.AreEqual("4015 7TH AVE APT 4B", t("4015 7th Avenue apt 4b"))
	End Sub
	<TestMethod()> _
	Public Sub test25200000()
		Assert.AreEqual("4015 7TH AVE APT B4", t("4015 7th Avenue apt b4"))
	End Sub
	<TestMethod()> _
	Public Sub test25300000()
		Assert.AreEqual("4015 7TH AVE # B4", t("4015 7th Avenue #b4"))
	End Sub
	<TestMethod()> _
	Public Sub test25400000()
		Assert.AreEqual("2 PARK AVE", t("Two Park Av"))
	End Sub
	<TestMethod()> _
	Public Sub test25500000()
		Assert.AreEqual("119 W 23RD ST", t("119 West 23 Street"))
	End Sub
	<TestMethod()> _
	Public Sub test25600000()
		Assert.AreEqual("444 N CAPITOL ST NW # 225", t("444 N Capitol Street  NW  #225"))
	End Sub
	<TestMethod()> _
	Public Sub test26400000()
		Assert.AreEqual("842 E BROADWAY", t("842 East Broadway"))
	End Sub
	<TestMethod()> _
	Public Sub test26500000()
		Assert.AreEqual("842 BROADWAY", t("842 Broadway"))
	End Sub
	<TestMethod()> _
	Public Sub test26900000()
		Assert.AreEqual("1 WASHINGTON SQUARE VLG APT 3D", t("One Washington Square Village Apartment 3D"))
	End Sub
	<TestMethod()> _
	Public Sub test27000000()
		Assert.AreEqual("1 WASHINGTON SQUARE VLG APT 3D", t("One Washington Sq Village Apartment 3D"))
	End Sub
	<TestMethod()> _
	Public Sub test28000000()
		Assert.AreEqual("618 FLAME RD FL 33", t("618 Flame Road  33rd Floor"))
	End Sub
	<TestMethod()> _
	Public Sub test29100000()
		Assert.AreEqual("3726 LAKE SAINT GEORGE DR", t("3726 Lake Saint George Dr"))
	End Sub
	<TestMethod()> _
	Public Sub test29120000()
		Assert.AreEqual("3726 LAKE SAINT GEORGE DR", t("3726 Lake St. George Dr"))
	End Sub
	<TestMethod()> _
	Public Sub test29130000()
		Assert.AreEqual("3726 LAKE ST", t("3726 Lake St"))
	End Sub
	<TestMethod()> _
	Public Sub test29150000()
		Assert.AreEqual("28 W FORSYTH STREET PL", t("28 West Forsyth Street Pl"))
	End Sub
	<TestMethod()> _
	Public Sub test29155000()
		Assert.AreEqual("28 FORSYTH STREET PL", t("28 Forsyth Street Pl"))
	End Sub
	<TestMethod()> _
	Public Sub test29160000()
		Assert.AreEqual("28 W FORSYTH STREET PL", t("28 West Forsyth St Pl"))
	End Sub
	<TestMethod()> _
	Public Sub test29170000()
		Assert.AreEqual("28 W SAINT FORSYTH PL", t("28 West St Forsyth Pl"))
	End Sub
	<TestMethod()> _
	Public Sub test29180000()
		Assert.AreEqual("28 SAINT FORSYTH PL", t("28 St Forsyth Pl"))
	End Sub
	'<TestMethod()> _
	'public sub test29190000()
	'	Assert.AreEqual("SAINT FORSYTH ST N DREMEL PL", t("Saint Forsyth Street North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29195000()
	'	Assert.AreEqual("SAINT FORSYTH ST N DREMEL PL", t("St Forsyth Street North Dremel Pl"))
	'end sub
	<TestMethod()> _
	Public Sub test29200000()
		Assert.AreEqual("2 W 42ND ST APT 4D", t("2 West 42 ST Apt. 4D"))
	End Sub
	'<TestMethod()> _
	'public sub test29206000()
	'	Assert.AreEqual("42ND ST 58TH AVE", t("42 St 58 Ave"))
	'end sub
	'<TestMethod()> _
	'public sub test29208000()
	'	Assert.AreEqual("42ND ST 58TH AVE", t("42 Street 58 Avenue"))
	'end sub
	'<TestMethod()> _
	'public sub test29210000()
	'	Assert.AreEqual("W 42ND ST 58TH AVE APT 4D", t("West 42 ST 58 Av Apt. 4D"))
	'end sub
	'<TestMethod()> _
	'public sub test29220000()
	'	Assert.AreEqual("FORSYTH ST DREMEL PL", t("Forsyth St Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29225000()
	'	Assert.AreEqual("FORSYTH ST DREMEL PL", t("Forsyth Street Dremel Place"))
	'end sub
	'<TestMethod()> _
	'public sub test29230000()
	'	Assert.AreEqual("W SAINT FORSYTH ST N DREMEL PL", t("West St Forsyth St North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29233000()
	'	Assert.AreEqual("W SAINT FORSYTH ST N DREMEL PL", t("West St Forsyth Street North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29236000()
	'	Assert.AreEqual("W SAINT FORSYTH ST N DREMEL PL", t("West Saint Forsyth St North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29238000()
	'	Assert.AreEqual("W SAINT FORSYTH ST N DREMEL PL", t("West Saint Forsyth Street North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29240000()
	'	Assert.AreEqual("W FORSYTH ST N DREMEL PL", t("West Forsyth St North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29245000()
	'	Assert.AreEqual("W FORSYTH ST N DREMEL PL", t("West Forsyth Street North Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29250000()
	'	Assert.AreEqual("38 W SAINT DREMEL PL", t("38 West St Dremel Pl"))
	'end sub
	'<TestMethod()> _
	'public sub test29255000()
	'	Assert.AreEqual("38 W SAINT DREMEL PL", t("38 West Saint Dremel Pl"))
	'end sub
	<TestMethod()> _
	Public Sub test29300000()
		Assert.AreEqual("4513 3RD STREET CIR W", t("4513 3 STREET CIRCLE WEST"))
	End Sub
	<TestMethod()> _
	Public Sub test29310000()
		Assert.AreEqual("4513 3RD STREET CIR W", t("4513 3 ST CIRCLE WEST"))
	End Sub
	<TestMethod()> _
	Public Sub test29400000()
		Assert.AreEqual("789 MAIN AVENUE DR", t("789 MAIN AVE DRIVE"))
	End Sub
	<TestMethod()> _
	Public Sub test29410000()
		Assert.AreEqual("789 MAIN AVENUE DR", t("789 MAIN AVENUE DRIVE"))
	End Sub
	<TestMethod()> _
	Public Sub test29500000()
		Assert.AreEqual("1 LA JOLLA BLVD", t("1 La Jolla Boulevard"))
	End Sub
	'<TestMethod()> _
	'public sub test29510000()
	'	Assert.AreEqual("LA JOLLA BLVD HOLLYWOOD BLVD", t("La Jolla Blvd Hollywood Blvd"))
	'end sub
	'<TestMethod()> _
	'public sub test29510100()
	'	Assert.AreEqual("LA JOLLA BLVD HOLLYWOOD BLVD", t("La Jolla Boulevard Hollywood Boulevard"))
	'end sub
	'<TestMethod()> _
	'public sub test29520000()
	'	Assert.AreEqual("HOLLYWOOD BLVD LA JOLLA BLVD", t("Hollywood Blvd La Jolla Blvd"))
	'end sub
	'<TestMethod()> _
	'public sub test29520100()
	'	Assert.AreEqual("HOLLYWOOD BLVD LA JOLLA BLVD", t("Hollywood Boulevard La Jolla Boulevard"))
	'end sub
	'<TestMethod()> _
	'public sub test29530000()
	'	Assert.AreEqual("JACKSON LN MAIN ST", t("Jackson La Main St"))
	'end sub
	'<TestMethod()> _
	'public sub test29533000()
	'	Assert.AreEqual("JACKSON LN MAIN ST", t("Jackson Ln Main St"))
	'end sub
	'<TestMethod()> _
	'public sub test29535000()
	'	Assert.AreEqual("JACKSON LN MAIN ST", t("Jackson Lane Main St"))
	'end sub
	'<TestMethod()> _
	'public sub test29536000()
	'	Assert.AreEqual("W JACKSON LN E MAIN ST", t("West Jackson Lane East Main St"))
	'end sub
	'<TestMethod()> _
	'public sub test29537000()
	'	Assert.AreEqual("JACKSON LN E MAIN ST", t("Jackson Lane East Main St"))
	'end sub
	'<TestMethod()> _
	'public sub test29538000()
	'	Assert.AreEqual("W JACKSON LN MAIN ST", t("West Jackson Lane Main St"))
	'end sub
	'<TestMethod()> _
	'public sub test29539000()
	'	Assert.AreEqual("W JACKSON LN MAIN STREET PLZ", t("West Jackson Lane Main St Plaza"))
	'end sub
	'<TestMethod()> _
	'public sub test29539500()
	'	Assert.AreEqual("W JACKSON LN MAIN STREET PLZ", t("West Jackson Lane Main Street Plaza"))
	'end sub
	<TestMethod()> _
	Public Sub test30000000()
		Assert.AreEqual("53 VIA NORTE DR", t("53 Via Norte Drive"))
	End Sub
	<TestMethod()> _
	Public Sub test30010000()
		Assert.AreEqual("53 N VIA DEL SUR DR", t("53 North Via Del Sur Drive"))
	End Sub
	<TestMethod()> _
	Public Sub test30020000()
		Assert.AreEqual("53 N VIADUCT DR", t("53 North Viaduct Drive"))
	End Sub
	<TestMethod()> _
	Public Sub test30101000()
		Assert.AreEqual("HC 33 BOX 44", t("highway contract route 33 box 44"))
	End Sub
	<TestMethod()> _
	Public Sub test30102000()
		Assert.AreEqual("HC 33 BOX 44", t("hcr 33 box 44"))
	End Sub
	<TestMethod()> _
	Public Sub test30103000()
		Assert.AreEqual("HC 33 BOX 44", t("star route 33 box 44"))
	End Sub
	<TestMethod()> _
	Public Sub test30104000()
		Assert.AreEqual("HC 33 BOX 44", t("hc 33 box 44"))
	End Sub
	<TestMethod()> _
	Public Sub test30105000()
		Assert.AreEqual("HC 33 BOX 44", t("hc # 33 box # 44"))
	End Sub
	<TestMethod()> _
	Public Sub test30106000()
		Assert.AreEqual("HC 33 BOX 44", t("highway contract 33 box 44"))
	End Sub
	<TestMethod()> _
	Public Sub test31000000()
		Assert.AreEqual("727 S E MAIN ST S220", t("727 S. E. Main Street, S-220"))
	End Sub
	<TestMethod()> _
	Public Sub test31110000()
		Assert.AreEqual("701 GROVE RD TERC FL 5", t("701 Grove Rd/TERC 5th Floor"))
	End Sub
	<TestMethod()> _
	Public Sub test31120000()
		Assert.AreEqual("701 GROVE RD ETC", t("701 Grove Road/ETC"))
	End Sub
	<TestMethod()> _
	Public Sub test31130000()
		Assert.AreEqual("701 GROVE RD ROGER C PEACE", t("701 Grove Road/Roger C. Peace"))
	End Sub
	<TestMethod()> _
	Public Sub test31140000()
		Assert.AreEqual("701 GROVE RD FL 5 PULM", t("701 Grove Road/5th Fl. Pulm"))
	End Sub
	<TestMethod()> _
	Public Sub test31200000()
		Assert.AreEqual("200 PATEWOOD DR SA120", t("200 Patewood Drive,SA120"))
	End Sub
End Class
