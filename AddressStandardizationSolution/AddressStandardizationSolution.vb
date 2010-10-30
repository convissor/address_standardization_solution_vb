Option Strict On
Option Explicit On

Imports System.Text.RegularExpressions
' .NET Framework 2.0 needs this for dictionaries.
Imports System.Collections.Generic

''' <summary>
''' Formats a Delivery Address Line according to the United States Postal
''' Service's Addressing Standards
''' </summary>
''' <remarks>
''' <para>Address Standardization Solution is a trademark of The Analysis and Solutions Company.</para>
'''
''' <para>Requires .NET Framework 2.0 or later.</para>
'''
''' <para>Author: Daniel Convissor danielc@analysisandsolutions.com</para>
''' <para>Copyright: The Analysis and Solutions Company, 2001-2010</para>
''' <para>License: http://www.analysisandsolutions.com/software/license.htm Simple Public License</para>
''' <para>Link: http://www.analysisandsolutions.com/software/addr/addr.htm</para>
''' </remarks>
<CLSCompliant(True)> _
Public Class AddressStandardizationSolution
	''' <summary>
	''' A dictionary with compass directions as keys and abbreviations as values
	''' </summary>
	''' <remarks>Note: entries ending in "-R" are for reverse lookup.</remarks>
	Public directionals As Dictionary(Of String, String) = New Dictionary(Of String, String)

	''' <summary>
	''' A dictionary with room types as keys and abbreviations as values
	''' </summary>
	''' <remarks>Note: entries ending in "-R" are for reverse lookup.</remarks>
	Public identifiers As Dictionary(Of String, String) = New Dictionary(Of String, String)

	''' <summary>
	''' A dictionary with numeric words as keys and numbers as values
	''' </summary>
	Public numbers As Dictionary(Of String, String) = New Dictionary(Of String, String)

	''' <summary>
	''' A dictionary with state names as keys and abbreviations as values
	''' </summary>
	Public states As Dictionary(Of String, String) = New Dictionary(Of String, String)

	''' <summary>
	''' A dictionary with street types as keys and abbreviations as values
	''' </summary>
	''' <remarks>Note: entries ending in "-R" are for reverse lookup.</remarks>
	Public suffixes As Dictionary(Of String, String) = New Dictionary(Of String, String)

	''' <summary>
	''' A dictionary with things that look like street types but are actually names
	''' </summary>
	''' <remarks>Note: entries ending in "-R" are for reverse lookup.</remarks>
	Public suffixSimiles As Dictionary(Of String, String) = New Dictionary(Of String, String)


	''' <summary>
	''' Automatically populates the class member variables when the object
	''' is instantiated
	''' </summary>
	Public Sub New()
		With directionals
			.Add("E", "E")
			.Add("EAST", "E")
			.Add("E-R", "EAST")
			.Add("N", "N")
			.Add("NO", "N")
			.Add("NORTH", "N")
			.Add("N-R", "NORTH")
			.Add("NE", "NE")
			.Add("NORTHEAST", "NE")
			.Add("NE-R", "NORTHEAST")
			.Add("NORTHWEST", "NW")
			.Add("NW-R", "NORTHWEST")
			.Add("NW", "NW")
			.Add("S", "S")
			.Add("SO", "S")
			.Add("SOUTH", "S")
			.Add("S-R", "SOUTH")
			.Add("SE", "SE")
			.Add("SOUTHEAST", "SE")
			.Add("SE-R", "SOUTHEAST")
			.Add("SOUTHWEST", "SW")
			.Add("SW-R", "SOUTHWEST")
			.Add("SW", "SW")
			.Add("W", "W")
			.Add("WEST", "W")
			.Add("W-R", "WEST")
		End With

		With identifiers
			.Add("APARTMENT", "APT")
			.Add("APT-R", "APARTMENT")
			.Add("APT", "APT")
			.Add("BLDG", "BLDG")
			.Add("BUILDING", "BLDG")
			.Add("BLDG-R", "BUILDING")
			.Add("BOX", "BOX")
			.Add("BOX-R", "BOX")
			.Add("BASEMENT", "BSMT")
			.Add("BSMT-R", "BASEMENT")
			.Add("BSMT", "BSMT")
			.Add("DEPARTMENT", "DEPT")
			.Add("DEPT-R", "DEPARTMENT")
			.Add("DEPT", "DEPT")
			.Add("FL", "FL")
			.Add("FLOOR", "FL")
			.Add("FL-R", "FLOOR")
			.Add("FRNT", "FRNT")
			.Add("FRONT", "FRNT")
			.Add("FRNT-R", "FRONT")
			.Add("HANGER", "HNGR")
			.Add("HNGR-R", "HANGER")
			.Add("HNGR", "HNGR")
			.Add("KEY", "KEY")
			.Add("KEY-R", "KEY")
			.Add("LBBY", "LBBY")
			.Add("LOBBY", "LBBY")
			.Add("LBBY-R", "LOBBY")
			.Add("LOT", "LOT")
			.Add("LOT-R", "LOT")
			.Add("LOWER", "LOWR")
			.Add("LOWR-R", "LOWER")
			.Add("LOWR", "LOWR")
			.Add("OFC", "OFC")
			.Add("OFFICE", "OFC")
			.Add("OFC-R", "OFFICE")
			.Add("PENTHOUSE", "PH")
			.Add("PH-R", "PENTHOUSE")
			.Add("PH", "PH")
			.Add("PIER", "PIER")
			.Add("PIER-R", "PIER")
			.Add("PMB", "PMB")
			.Add("PMB-R", "PMB")
			.Add("REAR", "REAR")
			.Add("REAR-R", "REAR")
			.Add("RM", "RM")
			.Add("ROOM", "RM")
			.Add("RM-R", "ROOM")
			.Add("SIDE", "SIDE")
			.Add("SIDE-R", "SIDE")
			.Add("SLIP", "SLIP")
			.Add("SLIP-R", "SLIP")
			.Add("SPACE", "SPC")
			.Add("SPC-R", "SPACE")
			.Add("SPC", "SPC")
			.Add("STE", "STE")
			.Add("SUITE", "STE")
			.Add("STE-R", "SUITE")
			.Add("STOP", "STOP")
			.Add("STOP-R", "STOP")
			.Add("TRAILER", "TRLR")
			.Add("TRLR-R", "TRAILER")
			.Add("TRLR", "TRLR")
			.Add("UNIT", "UNIT")
			.Add("UNIT-R", "UNIT")
			.Add("UPPER", "UPPR")
			.Add("UPPR-R", "UPPER")
			.Add("UPPR", "UPPR")
			.Add("UPR", "UPPR")
		End With

		With numbers
			.Add("FIRST", "1")
			.Add("ONE", "1")
			.Add("TEN", "10")
			.Add("TENTH", "10")
			.Add("ELEVEN", "11")
			.Add("ELEVENTH", "11")
			.Add("TWELFTH", "12")
			.Add("TWELVE", "12")
			.Add("THIRTEEN", "13")
			.Add("THIRTEENTH", "13")
			.Add("FOURTEEN", "14")
			.Add("FOURTEENTH", "14")
			.Add("FIFTEEN", "15")
			.Add("FIFTEENTH", "15")
			.Add("SIXTEEN", "16")
			.Add("SIXTEENTH", "16")
			.Add("SEVENTEEN", "17")
			.Add("SEVENTEENTH", "17")
			.Add("EIGHTEEN", "18")
			.Add("EIGHTEENTH", "18")
			.Add("NINETEEN", "19")
			.Add("NINETEENTH", "19")
			.Add("SECOND", "2")
			.Add("TWO", "2")
			.Add("TWENTIETH", "20")
			.Add("TWENTY", "20")
			.Add("THIRD", "3")
			.Add("THREE", "3")
			.Add("FOUR", "4")
			.Add("FOURTH", "4")
			.Add("FIFTH", "5")
			.Add("FIVE", "5")
			.Add("SIX", "6")
			.Add("SIXTH", "6")
			.Add("SEVEN", "7")
			.Add("SEVENTH", "7")
			.Add("EIGHT", "8")
			.Add("EIGHTH", "8")
			.Add("NINE", "9")
			.Add("NINTH", "9")
		End With

		With states
			.Add("ARMED FORCES AMERICA", "AA")
			.Add("ARMED FORCES EUROPE", "AE")
			.Add("ALASKA", "AK")
			.Add("ALABAMA", "AL")
			.Add("ARMED FORCES PACIFIC", "AP")
			.Add("ARKANSAS", "AR")
			.Add("ARIZONA", "AZ")
			.Add("CALIFORNIA", "CA")
			.Add("COLORADO", "CO")
			.Add("CONNECTICUT", "CT")
			.Add("DISTRICT OF COLUMBIA", "DC")
			.Add("DELAWARE", "DE")
			.Add("FLORIDA", "FL")
			.Add("GEORGIA", "GA")
			.Add("HAWAII", "HI")
			.Add("IOWA", "IA")
			.Add("IDAHO", "ID")
			.Add("ILLINOIS", "IL")
			.Add("INDIANA", "IN")
			.Add("KANSAS", "KS")
			.Add("KENTUCKY", "KY")
			.Add("LOUISIANA", "LA")
			.Add("MASSACHUSETTS", "MA")
			.Add("MARYLAND", "MD")
			.Add("MAINE", "ME")
			.Add("MICHIGAN", "MI")
			.Add("MINNESOTA", "MN")
			.Add("MISSOURI", "MO")
			.Add("MISSISSIPPI", "MS")
			.Add("MONTANA", "MT")
			.Add("NORTH CAROLINA", "NC")
			.Add("NORTH DAKOTA", "ND")
			.Add("NEBRASKA", "NE")
			.Add("NEW HAMPSHIRE", "NH")
			.Add("NEW JERSEY", "NJ")
			.Add("NEW MEXICO", "NM")
			.Add("NEVADA", "NV")
			.Add("NEW YORK", "NY")
			.Add("OHIO", "OH")
			.Add("OKLAHOMA", "OK")
			.Add("OREGON", "OR")
			.Add("PENNSYLVANIA", "PA")
			.Add("RHODE ISLAND", "RI")
			.Add("SOUTH CAROLINA", "SC")
			.Add("SOUTH DAKOTA", "SD")
			.Add("TENNESSEE", "TN")
			.Add("TEXAS", "TX")
			.Add("UTAH", "UT")
			.Add("VIRGINIA", "VA")
			.Add("VERMONT", "VT")
			.Add("WASHINGTON", "WA")
			.Add("WISCONSIN", "WI")
			.Add("WEST VIRGINIA", "WV")
			.Add("WYOMING", "WY")
		End With

		With suffixes
			.Add("ALLEE", "ALY")
			.Add("ALLEY", "ALY")
			.Add("ALY-R", "ALLEY")
			.Add("ALLY", "ALY")
			.Add("ALY", "ALY")
			.Add("ANEX", "ANX")
			.Add("ANNEX", "ANX")
			.Add("ANX-R", "ANNEX")
			.Add("ANNX", "ANX")
			.Add("ANX", "ANX")
			.Add("ARC", "ARC")
			.Add("ARCADE", "ARC")
			.Add("ARC-R", "ARCADE")
			.Add("AV", "AVE")
			.Add("AVE", "AVE")
			.Add("AVEN", "AVE")
			.Add("AVENU", "AVE")
			.Add("AVENUE", "AVE")
			.Add("AVE-R", "AVENUE")
			.Add("AVN", "AVE")
			.Add("AVNUE", "AVE")
			.Add("BCH", "BCH")
			.Add("BEACH", "BCH")
			.Add("BCH-R", "BEACH")
			.Add("BG", "BG")
			.Add("BURG", "BG")
			.Add("BG-R", "BURG")
			.Add("BGS", "BGS")
			.Add("BURGS", "BGS")
			.Add("BGS-R", "BURGS")
			.Add("BLF", "BLF")
			.Add("BLUF", "BLF")
			.Add("BLUFF", "BLF")
			.Add("BLF-R", "BLUFF")
			.Add("BLFS", "BLFS")
			.Add("BLUFFS", "BLFS")
			.Add("BLFS-R", "BLUFFS")
			.Add("BLVD", "BLVD")
			.Add("BLVRD", "BLVD")
			.Add("BOUL", "BLVD")
			.Add("BOULEVARD", "BLVD")
			.Add("BLVD-R", "BOULEVARD")
			.Add("BOULOVARD", "BLVD")
			.Add("BOULV", "BLVD")
			.Add("BOULVRD", "BLVD")
			.Add("BULAVARD", "BLVD")
			.Add("BULEVARD", "BLVD")
			.Add("BULLEVARD", "BLVD")
			.Add("BULOVARD", "BLVD")
			.Add("BULVD", "BLVD")
			.Add("BEND", "BND")
			.Add("BND-R", "BEND")
			.Add("BND", "BND")
			.Add("BR", "BR")
			.Add("BRANCH", "BR")
			.Add("BR-R", "BRANCH")
			.Add("BRNCH", "BR")
			.Add("BRDGE", "BRG")
			.Add("BRG", "BRG")
			.Add("BRGE", "BRG")
			.Add("BRIDGE", "BRG")
			.Add("BRG-R", "BRIDGE")
			.Add("BRK", "BRK")
			.Add("BROOK", "BRK")
			.Add("BRK-R", "BROOK")
			.Add("BRKS", "BRKS")
			.Add("BROOKS", "BRKS")
			.Add("BRKS-R", "BROOKS")
			.Add("BOT", "BTM")
			.Add("BOTTM", "BTM")
			.Add("BOTTOM", "BTM")
			.Add("BTM-R", "BOTTOM")
			.Add("BTM", "BTM")
			.Add("BYP", "BYP")
			.Add("BYPA", "BYP")
			.Add("BYPAS", "BYP")
			.Add("BYPASS", "BYP")
			.Add("BYP-R", "BYPASS")
			.Add("BYPS", "BYP")
			.Add("BAYOO", "BYU")
			.Add("BAYOU", "BYU")
			.Add("BYU-R", "BAYOU")
			.Add("BYO", "BYU")
			.Add("BYOU", "BYU")
			.Add("BYU", "BYU")
			.Add("CIR", "CIR")
			.Add("CIRC", "CIR")
			.Add("CIRCEL", "CIR")
			.Add("CIRCL", "CIR")
			.Add("CIRCLE", "CIR")
			.Add("CIR-R", "CIRCLE")
			.Add("CRCL", "CIR")
			.Add("CRCLE", "CIR")
			.Add("CIRCELS", "CIRS")
			.Add("CIRCLES", "CIRS")
			.Add("CIRS-R", "CIRCLES")
			.Add("CIRCLS", "CIRS")
			.Add("CIRCS", "CIRS")
			.Add("CIRS", "CIRS")
			.Add("CRCLES", "CIRS")
			.Add("CRCLS", "CIRS")
			.Add("CLB", "CLB")
			.Add("CLUB", "CLB")
			.Add("CLB-R", "CLUB")
			.Add("CLF", "CLF")
			.Add("CLIF", "CLF")
			.Add("CLIFF", "CLF")
			.Add("CLF-R", "CLIFF")
			.Add("CLFS", "CLFS")
			.Add("CLIFFS", "CLFS")
			.Add("CLFS-R", "CLIFFS")
			.Add("CLIFS", "CLFS")
			.Add("CMN", "CMN")
			.Add("COMMON", "CMN")
			.Add("CMN-R", "COMMON")
			.Add("COMN", "CMN")
			.Add("COR", "COR")
			.Add("CORN", "COR")
			.Add("CORNER", "COR")
			.Add("COR-R", "CORNER")
			.Add("CRNR", "COR")
			.Add("CORNERS", "CORS")
			.Add("CORS-R", "CORNERS")
			.Add("CORNRS", "CORS")
			.Add("CORS", "CORS")
			.Add("CRNRS", "CORS")
			.Add("CAMP", "CP")
			.Add("CP-R", "CAMP")
			.Add("CMP", "CP")
			.Add("CP", "CP")
			.Add("CAPE", "CPE")
			.Add("CPE-R", "CAPE")
			.Add("CPE", "CPE")
			.Add("CRECENT", "CRES")
			.Add("CRES", "CRES")
			.Add("CRESCENT", "CRES")
			.Add("CRES-R", "CRESCENT")
			.Add("CRESENT", "CRES")
			.Add("CRSCNT", "CRES")
			.Add("CRSENT", "CRES")
			.Add("CRSNT", "CRES")
			.Add("CK", "CRK")
			.Add("CR", "CRK")
			.Add("CREEK", "CRK")
			.Add("CRK-R", "CREEK")
			.Add("CREK", "CRK")
			.Add("CRK", "CRK")
			.Add("COARSE", "CRSE")
			.Add("COURSE", "CRSE")
			.Add("CRSE-R", "COURSE")
			.Add("CRSE", "CRSE")
			.Add("CREST", "CRST")
			.Add("CRST-R", "CREST")
			.Add("CRST", "CRST")
			.Add("CAUSEWAY", "CSWY")
			.Add("CSWY-R", "CAUSEWAY")
			.Add("CAUSEWY", "CSWY")
			.Add("CAUSWAY", "CSWY")
			.Add("CAUSWY", "CSWY")
			.Add("CSWY", "CSWY")
			.Add("CORT", "CT")
			.Add("COURT", "CT")
			.Add("CT-R", "COURT")
			.Add("CRT", "CT")
			.Add("CT", "CT")
			.Add("CEN", "CTR")
			.Add("CENT", "CTR")
			.Add("CENTER", "CTR")
			.Add("CTR-R", "CENTER")
			.Add("CENTR", "CTR")
			.Add("CENTRE", "CTR")
			.Add("CNTER", "CTR")
			.Add("CNTR", "CTR")
			.Add("CTR", "CTR")
			.Add("CENS", "CTRS")
			.Add("CENTERS", "CTRS")
			.Add("CTRS-R", "CENTERS")
			.Add("CENTRES", "CTRS")
			.Add("CENTRS", "CTRS")
			.Add("CENTS", "CTRS")
			.Add("CNTERS", "CTRS")
			.Add("CNTRS", "CTRS")
			.Add("CTRS", "CTRS")
			.Add("COURTS", "CTS")
			.Add("CTS-R", "COURTS")
			.Add("CTS", "CTS")
			.Add("CRV", "CURV")
			.Add("CURV", "CURV")
			.Add("CURVE", "CURV")
			.Add("CURV-R", "CURVE")
			.Add("COV", "CV")
			.Add("COVE", "CV")
			.Add("CV-R", "COVE")
			.Add("CV", "CV")
			.Add("COVES", "CVS")
			.Add("CVS-R", "COVES")
			.Add("COVS", "CVS")
			.Add("CVS", "CVS")
			.Add("CAN", "CYN")
			.Add("CANYN", "CYN")
			.Add("CANYON", "CYN")
			.Add("CYN-R", "CANYON")
			.Add("CNYN", "CYN")
			.Add("CYN", "CYN")
			.Add("DAL", "DL")
			.Add("DALE", "DL")
			.Add("DL-R", "DALE")
			.Add("DL", "DL")
			.Add("DAM", "DM")
			.Add("DM-R", "DAM")
			.Add("DM", "DM")
			.Add("DR", "DR")
			.Add("DRIV", "DR")
			.Add("DRIVE", "DR")
			.Add("DR-R", "DRIVE")
			.Add("DRV", "DR")
			.Add("DRIVES", "DRS")
			.Add("DRS-R", "DRIVES")
			.Add("DRIVS", "DRS")
			.Add("DRS", "DRS")
			.Add("DRVS", "DRS")
			.Add("DIV", "DV")
			.Add("DIVD", "DV")
			.Add("DIVID", "DV")
			.Add("DIVIDE", "DV")
			.Add("DV-R", "DIVIDE")
			.Add("DV", "DV")
			.Add("DVD", "DV")
			.Add("EST", "EST")
			.Add("ESTA", "EST")
			.Add("ESTATE", "EST")
			.Add("EST-R", "ESTATE")
			.Add("ESTAS", "ESTS")
			.Add("ESTATES", "ESTS")
			.Add("ESTS-R", "ESTATES")
			.Add("ESTS", "ESTS")
			.Add("EXP", "EXPY")
			.Add("EXPR", "EXPY")
			.Add("EXPRESS", "EXPY")
			.Add("EXPRESSWAY", "EXPY")
			.Add("EXPY-R", "EXPRESSWAY")
			.Add("EXPRESWAY", "EXPY")
			.Add("EXPRSWY", "EXPY")
			.Add("EXPRWY", "EXPY")
			.Add("EXPW", "EXPY")
			.Add("EXPWY", "EXPY")
			.Add("EXPY", "EXPY")
			.Add("EXWAY", "EXPY")
			.Add("EXWY", "EXPY")
			.Add("EXT", "EXT")
			.Add("EXTEN", "EXT")
			.Add("EXTENSION", "EXT")
			.Add("EXT-R", "EXTENSION")
			.Add("EXTENSN", "EXT")
			.Add("EXTN", "EXT")
			.Add("EXTNSN", "EXT")
			.Add("EXTENS", "EXTS")
			.Add("EXTENSIONS", "EXTS")
			.Add("EXTS-R", "EXTENSIONS")
			.Add("EXTENSNS", "EXTS")
			.Add("EXTNS", "EXTS")
			.Add("EXTNSNS", "EXTS")
			.Add("EXTS", "EXTS")
			.Add("FAL", "FALL")
			.Add("FALL", "FALL")
			.Add("FALL-R", "FALL")
			.Add("FIELD", "FLD")
			.Add("FLD-R", "FIELD")
			.Add("FLD", "FLD")
			.Add("FIELDS", "FLDS")
			.Add("FLDS-R", "FIELDS")
			.Add("FLDS", "FLDS")
			.Add("FALLS", "FLS")
			.Add("FLS-R", "FALLS")
			.Add("FALS", "FLS")
			.Add("FLS", "FLS")
			.Add("FLAT", "FLT")
			.Add("FLT-R", "FLAT")
			.Add("FLT", "FLT")
			.Add("FLATS", "FLTS")
			.Add("FLTS-R", "FLATS")
			.Add("FLTS", "FLTS")
			.Add("FORD", "FRD")
			.Add("FRD-R", "FORD")
			.Add("FRD", "FRD")
			.Add("FORDS", "FRDS")
			.Add("FRDS-R", "FORDS")
			.Add("FRDS", "FRDS")
			.Add("FORG", "FRG")
			.Add("FORGE", "FRG")
			.Add("FRG-R", "FORGE")
			.Add("FRG", "FRG")
			.Add("FORGES", "FRGS")
			.Add("FRGS-R", "FORGES")
			.Add("FRGS", "FRGS")
			.Add("FORK", "FRK")
			.Add("FRK-R", "FORK")
			.Add("FRK", "FRK")
			.Add("FORKS", "FRKS")
			.Add("FRKS-R", "FORKS")
			.Add("FRKS", "FRKS")
			.Add("FOREST", "FRST")
			.Add("FRST-R", "FOREST")
			.Add("FORESTS", "FRST")
			.Add("FORREST", "FRST")
			.Add("FORRESTS", "FRST")
			.Add("FORRST", "FRST")
			.Add("FORRSTS", "FRST")
			.Add("FORST", "FRST")
			.Add("FORSTS", "FRST")
			.Add("FRRESTS", "FRST")
			.Add("FRRST", "FRST")
			.Add("FRRSTS", "FRST")
			.Add("FRST", "FRST")
			.Add("FERRY", "FRY")
			.Add("FRY-R", "FERRY")
			.Add("FERY", "FRY")
			.Add("FRRY", "FRY")
			.Add("FRY", "FRY")
			.Add("FORT", "FT")
			.Add("FT-R", "FORT")
			.Add("FRT", "FT")
			.Add("FT", "FT")
			.Add("FREEWAY", "FWY")
			.Add("FWY-R", "FREEWAY")
			.Add("FREEWY", "FWY")
			.Add("FREWAY", "FWY")
			.Add("FREWY", "FWY")
			.Add("FRWAY", "FWY")
			.Add("FRWY", "FWY")
			.Add("FWY", "FWY")
			.Add("GARDEN", "GDN")
			.Add("GDN-R", "GARDEN")
			.Add("GARDN", "GDN")
			.Add("GDN", "GDN")
			.Add("GRDEN", "GDN")
			.Add("GRDN", "GDN")
			.Add("GARDENS", "GDNS")
			.Add("GDNS-R", "GARDENS")
			.Add("GARDNS", "GDNS")
			.Add("GDNS", "GDNS")
			.Add("GRDENS", "GDNS")
			.Add("GRDNS", "GDNS")
			.Add("GLEN", "GLN")
			.Add("GLN-R", "GLEN")
			.Add("GLENN", "GLN")
			.Add("GLN", "GLN")
			.Add("GLENNS", "GLNS")
			.Add("GLENS", "GLNS")
			.Add("GLNS-R", "GLENS")
			.Add("GLNS", "GLNS")
			.Add("GREEN", "GRN")
			.Add("GRN-R", "GREEN")
			.Add("GREN", "GRN")
			.Add("GRN", "GRN")
			.Add("GREENS", "GRNS")
			.Add("GRNS-R", "GREENS")
			.Add("GRENS", "GRNS")
			.Add("GRNS", "GRNS")
			.Add("GROV", "GRV")
			.Add("GROVE", "GRV")
			.Add("GRV-R", "GROVE")
			.Add("GRV", "GRV")
			.Add("GROVES", "GRVS")
			.Add("GRVS-R", "GROVES")
			.Add("GROVS", "GRVS")
			.Add("GRVS", "GRVS")
			.Add("GATEWAY", "GTWY")
			.Add("GTWY-R", "GATEWAY")
			.Add("GATEWY", "GTWY")
			.Add("GATWAY", "GTWY")
			.Add("GTWAY", "GTWY")
			.Add("GTWY", "GTWY")
			.Add("HARB", "HBR")
			.Add("HARBOR", "HBR")
			.Add("HBR-R", "HARBOR")
			.Add("HARBR", "HBR")
			.Add("HBR", "HBR")
			.Add("HRBOR", "HBR")
			.Add("HARBORS", "HBRS")
			.Add("HBRS-R", "HARBORS")
			.Add("HBRS", "HBRS")
			.Add("HILL", "HL")
			.Add("HL-R", "HILL")
			.Add("HL", "HL")
			.Add("HILLS", "HLS")
			.Add("HLS-R", "HILLS")
			.Add("HLS", "HLS")
			.Add("HLLW", "HOLW")
			.Add("HLLWS", "HOLW")
			.Add("HOLLOW", "HOLW")
			.Add("HOLW-R", "HOLLOW")
			.Add("HOLLOWS", "HOLW")
			.Add("HOLOW", "HOLW")
			.Add("HOLOWS", "HOLW")
			.Add("HOLW", "HOLW")
			.Add("HOLWS", "HOLW")
			.Add("HEIGHT", "HTS")
			.Add("HEIGHTS", "HTS")
			.Add("HTS-R", "HEIGHTS")
			.Add("HGTS", "HTS")
			.Add("HT", "HTS")
			.Add("HTS", "HTS")
			.Add("HAVEN", "HVN")
			.Add("HVN-R", "HAVEN")
			.Add("HAVN", "HVN")
			.Add("HVN", "HVN")
			.Add("HIGHWAY", "HWY")
			.Add("HWY-R", "HIGHWAY")
			.Add("HIGHWY", "HWY")
			.Add("HIWAY", "HWY")
			.Add("HIWY", "HWY")
			.Add("HWAY", "HWY")
			.Add("HWY", "HWY")
			.Add("HYGHWAY", "HWY")
			.Add("HYWAY", "HWY")
			.Add("HYWY", "HWY")
			.Add("INLET", "INLT")
			.Add("INLT-R", "INLET")
			.Add("INLT", "INLT")
			.Add("ILAND", "IS")
			.Add("ILND", "IS")
			.Add("IS", "IS")
			.Add("ISLAND", "IS")
			.Add("IS-R", "ISLAND")
			.Add("ISLND", "IS")
			.Add("ILE", "ISLE")
			.Add("ISLE", "ISLE")
			.Add("ISLE-R", "ISLE")
			.Add("ISLES", "ISLE")
			.Add("ILANDS", "ISS")
			.Add("ILNDS", "ISS")
			.Add("ISLANDS", "ISS")
			.Add("ISS-R", "ISLANDS")
			.Add("ISLDS", "ISS")
			.Add("ISLNDS", "ISS")
			.Add("ISS", "ISS")
			.Add("JCT", "JCT")
			.Add("JCTION", "JCT")
			.Add("JCTN", "JCT")
			.Add("JUNCTION", "JCT")
			.Add("JCT-R", "JUNCTION")
			.Add("JUNCTN", "JCT")
			.Add("JUNCTON", "JCT")
			.Add("JCTIONS", "JCTS")
			.Add("JCTNS", "JCTS")
			.Add("JCTS", "JCTS")
			.Add("JUNCTIONS", "JCTS")
			.Add("JCTS-R", "JUNCTIONS")
			.Add("JUNCTONS", "JCTS")
			.Add("JUNGTNS", "JCTS")
			.Add("KNL", "KNL")
			.Add("KNOL", "KNL")
			.Add("KNOLL", "KNL")
			.Add("KNL-R", "KNOLL")
			.Add("KNLS", "KNLS")
			.Add("KNOLLS", "KNLS")
			.Add("KNLS-R", "KNOLLS")
			.Add("KNOLS", "KNLS")
			.Add("KEY", "KY")
			.Add("KY-R", "KEY")
			.Add("KY", "KY")
			.Add("KEYS", "KYS")
			.Add("KYS-R", "KEYS")
			.Add("KYS", "KYS")
			.Add("LAND", "LAND")
			.Add("LAND-R", "LAND")
			.Add("LCK", "LCK")
			.Add("LOCK", "LCK")
			.Add("LCK-R", "LOCK")
			.Add("LCKS", "LCKS")
			.Add("LOCKS", "LCKS")
			.Add("LCKS-R", "LOCKS")
			.Add("LDG", "LDG")
			.Add("LDGE", "LDG")
			.Add("LODG", "LDG")
			.Add("LODGE", "LDG")
			.Add("LDG-R", "LODGE")
			.Add("LF", "LF")
			.Add("LOAF", "LF")
			.Add("LF-R", "LOAF")
			.Add("LGT", "LGT")
			.Add("LIGHT", "LGT")
			.Add("LGT-R", "LIGHT")
			.Add("LT", "LGT")
			.Add("LGTS", "LGTS")
			.Add("LIGHTS", "LGTS")
			.Add("LGTS-R", "LIGHTS")
			.Add("LTS", "LGTS")
			.Add("LAKE", "LK")
			.Add("LK-R", "LAKE")
			.Add("LK", "LK")
			.Add("LAKES", "LKS")
			.Add("LKS-R", "LAKES")
			.Add("LKS", "LKS")
			.Add("LA", "LN")
			.Add("LANE", "LN")
			.Add("LN-R", "LANE")
			.Add("LANES", "LN")
			.Add("LN", "LN")
			.Add("LNS", "LN")
			.Add("LANDG", "LNDG")
			.Add("LANDING", "LNDG")
			.Add("LNDG-R", "LANDING")
			.Add("LANDNG", "LNDG")
			.Add("LNDG", "LNDG")
			.Add("LNDNG", "LNDG")
			.Add("LOOP", "LOOP")
			.Add("LOOP-R", "LOOP")
			.Add("LOOPS", "LOOP")
			.Add("MALL", "MALL")
			.Add("MALL-R", "MALL")
			.Add("MDW", "MDW")
			.Add("MEADOW", "MDW")
			.Add("MDW-R", "MEADOW")
			.Add("MDWS", "MDWS")
			.Add("MEADOWS", "MDWS")
			.Add("MDWS-R", "MEADOWS")
			.Add("MEDOWS", "MDWS")
			.Add("MEDWS", "MDWS")
			.Add("MEWS", "MEWS")
			.Add("MEWS-R", "MEWS")
			.Add("MIL", "ML")
			.Add("MILL", "ML")
			.Add("ML-R", "MILL")
			.Add("ML", "ML")
			.Add("MILLS", "MLS")
			.Add("MLS-R", "MILLS")
			.Add("MILS", "MLS")
			.Add("MLS", "MLS")
			.Add("MANOR", "MNR")
			.Add("MNR-R", "MANOR")
			.Add("MANR", "MNR")
			.Add("MNR", "MNR")
			.Add("MANORS", "MNRS")
			.Add("MNRS-R", "MANORS")
			.Add("MANRS", "MNRS")
			.Add("MNRS", "MNRS")
			.Add("MISN", "MSN")
			.Add("MISSION", "MSN")
			.Add("MSN-R", "MISSION")
			.Add("MISSN", "MSN")
			.Add("MSN", "MSN")
			.Add("MSSN", "MSN")
			.Add("MNT", "MT")
			.Add("MOUNT", "MT")
			.Add("MT-R", "MOUNT")
			.Add("MT", "MT")
			.Add("MNTAIN", "MTN")
			.Add("MNTN", "MTN")
			.Add("MOUNTAIN", "MTN")
			.Add("MTN-R", "MOUNTAIN")
			.Add("MOUNTIN", "MTN")
			.Add("MTIN", "MTN")
			.Add("MTN", "MTN")
			.Add("MNTNS", "MTNS")
			.Add("MOUNTAINS", "MTNS")
			.Add("MTNS-R", "MOUNTAINS")
			.Add("MTNS", "MTNS")
			.Add("MOTORWAY", "MTWY")
			.Add("MTWY-R", "MOTORWAY")
			.Add("MOTORWY", "MTWY")
			.Add("MOTRWY", "MTWY")
			.Add("MOTWY", "MTWY")
			.Add("MTRWY", "MTWY")
			.Add("MTWY", "MTWY")
			.Add("NCK", "NCK")
			.Add("NECK", "NCK")
			.Add("NCK-R", "NECK")
			.Add("NEK", "NCK")
			.Add("OPAS", "OPAS")
			.Add("OVERPAS", "OPAS")
			.Add("OVERPASS", "OPAS")
			.Add("OPAS-R", "OVERPASS")
			.Add("OVERPS", "OPAS")
			.Add("OVRPS", "OPAS")
			.Add("ORCH", "ORCH")
			.Add("ORCHARD", "ORCH")
			.Add("ORCH-R", "ORCHARD")
			.Add("ORCHRD", "ORCH")
			.Add("OVAL", "OVAL")
			.Add("OVAL-R", "OVAL")
			.Add("OVL", "OVAL")
			.Add("PARK", "PARK")
			.Add("PARK-R", "PARK")
			.Add("PARKS", "PARK")
			.Add("PK", "PARK")
			.Add("PRK", "PARK")
			.Add("PAS", "PASS")
			.Add("PASS", "PASS")
			.Add("PASS-R", "PASS")
			.Add("PATH", "PATH")
			.Add("PATH-R", "PATH")
			.Add("PATHS", "PATH")
			.Add("PIKE", "PIKE")
			.Add("PIKE-R", "PIKE")
			.Add("PIKES", "PIKE")
			.Add("PARKWAY", "PKWY")
			.Add("PKWY-R", "PARKWAY")
			.Add("PARKWAYS", "PKWY")
			.Add("PARKWY", "PKWY")
			.Add("PKWAY", "PKWY")
			.Add("PKWY", "PKWY")
			.Add("PKWYS", "PKWY")
			.Add("PKY", "PKWY")
			.Add("PL", "PL")
			.Add("PLAC", "PL")
			.Add("PLACE", "PL")
			.Add("PL-R", "PLACE")
			.Add("PLASE", "PL")
			.Add("PLAIN", "PLN")
			.Add("PLN-R", "PLAIN")
			.Add("PLN", "PLN")
			.Add("PLAINES", "PLNS")
			.Add("PLAINS", "PLNS")
			.Add("PLNS-R", "PLAINS")
			.Add("PLNS", "PLNS")
			.Add("PLAZ", "PLZ")
			.Add("PLAZA", "PLZ")
			.Add("PLZ-R", "PLAZA")
			.Add("PLZ", "PLZ")
			.Add("PLZA", "PLZ")
			.Add("PZ", "PLZ")
			.Add("PINE", "PNE")
			.Add("PNE-R", "PINE")
			.Add("PNE", "PNE")
			.Add("PINES", "PNES")
			.Add("PNES-R", "PINES")
			.Add("PNES", "PNES")
			.Add("PR", "PR")
			.Add("PRAIR", "PR")
			.Add("PRAIRIE", "PR")
			.Add("PR-R", "PRAIRIE")
			.Add("PRARE", "PR")
			.Add("PRARIE", "PR")
			.Add("PRR", "PR")
			.Add("PRRE", "PR")
			.Add("PORT", "PRT")
			.Add("PRT-R", "PORT")
			.Add("PRT", "PRT")
			.Add("PORTS", "PRTS")
			.Add("PRTS-R", "PORTS")
			.Add("PRTS", "PRTS")
			.Add("PASG", "PSGE")
			.Add("PASSAGE", "PSGE")
			.Add("PSGE-R", "PASSAGE")
			.Add("PASSG", "PSGE")
			.Add("PSGE", "PSGE")
			.Add("PNT", "PT")
			.Add("POINT", "PT")
			.Add("PT-R", "POINT")
			.Add("PT", "PT")
			.Add("PNTS", "PTS")
			.Add("POINTS", "PTS")
			.Add("PTS-R", "POINTS")
			.Add("PTS", "PTS")
			.Add("RAD", "RADL")
			.Add("RADIAL", "RADL")
			.Add("RADL-R", "RADIAL")
			.Add("RADIEL", "RADL")
			.Add("RADL", "RADL")
			.Add("RAMP", "RAMP")
			.Add("RAMP-R", "RAMP")
			.Add("RD", "RD")
			.Add("ROAD", "RD")
			.Add("RD-R", "ROAD")
			.Add("RDG", "RDG")
			.Add("RDGE", "RDG")
			.Add("RIDGE", "RDG")
			.Add("RDG-R", "RIDGE")
			.Add("RDGS", "RDGS")
			.Add("RIDGES", "RDGS")
			.Add("RDGS-R", "RIDGES")
			.Add("RDS", "RDS")
			.Add("ROADS", "RDS")
			.Add("RDS-R", "ROADS")
			.Add("RIV", "RIV")
			.Add("RIVER", "RIV")
			.Add("RIV-R", "RIVER")
			.Add("RIVR", "RIV")
			.Add("RVR", "RIV")
			.Add("RANCH", "RNCH")
			.Add("RNCH-R", "RANCH")
			.Add("RANCHES", "RNCH")
			.Add("RNCH", "RNCH")
			.Add("RNCHS", "RNCH")
			.Add("RAOD", "RD")
			.Add("ROW", "ROW")
			.Add("ROW-R", "ROW")
			.Add("RAPID", "RPD")
			.Add("RPD-R", "RAPID")
			.Add("RPD", "RPD")
			.Add("RAPIDS", "RPDS")
			.Add("RPDS-R", "RAPIDS")
			.Add("RPDS", "RPDS")
			.Add("REST", "RST")
			.Add("RST-R", "REST")
			.Add("RST", "RST")
			.Add("ROUTE", "RTE")
			.Add("RTE-R", "ROUTE")
			.Add("RT", "RTE")
			.Add("RTE", "RTE")
			.Add("RUE", "RUE")
			.Add("RUE-R", "RUE")
			.Add("RUN", "RUN")
			.Add("RUN-R", "RUN")
			.Add("SHL", "SHL")
			.Add("SHOAL", "SHL")
			.Add("SHL-R", "SHOAL")
			.Add("SHOL", "SHL")
			.Add("SHLS", "SHLS")
			.Add("SHOALS", "SHLS")
			.Add("SHLS-R", "SHOALS")
			.Add("SHOLS", "SHLS")
			.Add("SHOAR", "SHR")
			.Add("SHORE", "SHR")
			.Add("SHR-R", "SHORE")
			.Add("SHR", "SHR")
			.Add("SHOARS", "SHRS")
			.Add("SHORES", "SHRS")
			.Add("SHRS-R", "SHORES")
			.Add("SHRS", "SHRS")
			.Add("SKWY", "SKWY")
			.Add("SKYWAY", "SKWY")
			.Add("SKWY-R", "SKYWAY")
			.Add("SKYWY", "SKWY")
			.Add("SMT", "SMT")
			.Add("SUMIT", "SMT")
			.Add("SUMITT", "SMT")
			.Add("SUMMIT", "SMT")
			.Add("SMT-R", "SUMMIT")
			.Add("SUMT", "SMT")
			.Add("SPG", "SPG")
			.Add("SPNG", "SPG")
			.Add("SPRING", "SPG")
			.Add("SPG-R", "SPRING")
			.Add("SPRNG", "SPG")
			.Add("SPGS", "SPGS")
			.Add("SPNGS", "SPGS")
			.Add("SPRINGS", "SPGS")
			.Add("SPGS-R", "SPRINGS")
			.Add("SPRNGS", "SPGS")
			.Add("SPR", "SPUR")
			.Add("SPRS", "SPUR")
			.Add("SPUR", "SPUR")
			.Add("SPUR-R", "SPUR")
			.Add("SPURS", "SPUR")
			.Add("SQ", "SQ")
			.Add("SQAR", "SQ")
			.Add("SQR", "SQ")
			.Add("SQRE", "SQ")
			.Add("SQU", "SQ")
			.Add("SQUARE", "SQ")
			.Add("SQ-R", "SQUARE")
			.Add("SQARS", "SQS")
			.Add("SQRS", "SQS")
			.Add("SQS", "SQS")
			.Add("SQUARES", "SQS")
			.Add("SQS-R", "SQUARES")
			.Add("ST", "ST")
			.Add("STR", "ST")
			.Add("STREET", "ST")
			.Add("ST-R", "STREET")
			.Add("STRT", "ST")
			.Add("STA", "STA")
			.Add("STATION", "STA")
			.Add("STA-R", "STATION")
			.Add("STATN", "STA")
			.Add("STN", "STA")
			.Add("STRA", "STRA")
			.Add("STRAV", "STRA")
			.Add("STRAVE", "STRA")
			.Add("STRAVEN", "STRA")
			.Add("STRAVENUE", "STRA")
			.Add("STRA-R", "STRAVENUE")
			.Add("STRAVN", "STRA")
			.Add("STRVN", "STRA")
			.Add("STRVNUE", "STRA")
			.Add("STREAM", "STRM")
			.Add("STRM-R", "STREAM")
			.Add("STREME", "STRM")
			.Add("STRM", "STRM")
			.Add("STREETS", "STS")
			.Add("STS-R", "STREETS")
			.Add("STS", "STS")
			.Add("TER", "TER")
			.Add("TERACE", "TER")
			.Add("TERASE", "TER")
			.Add("TERR", "TER")
			.Add("TERRACE", "TER")
			.Add("TER-R", "TERRACE")
			.Add("TERRASE", "TER")
			.Add("TERRC", "TER")
			.Add("TERRICE", "TER")
			.Add("TPK", "TPKE")
			.Add("TPKE", "TPKE")
			.Add("TRNPK", "TPKE")
			.Add("TRPK", "TPKE")
			.Add("TURNPIKE", "TPKE")
			.Add("TPKE-R", "TURNPIKE")
			.Add("TURNPK", "TPKE")
			.Add("TRACK", "TRAK")
			.Add("TRAK-R", "TRACK")
			.Add("TRACKS", "TRAK")
			.Add("TRAK", "TRAK")
			.Add("TRK", "TRAK")
			.Add("TRKS", "TRAK")
			.Add("TRACE", "TRCE")
			.Add("TRCE-R", "TRACE")
			.Add("TRACES", "TRCE")
			.Add("TRCE", "TRCE")
			.Add("TRAFFICWAY", "TRFY")
			.Add("TRFY-R", "TRAFFICWAY")
			.Add("TRAFFICWY", "TRFY")
			.Add("TRAFWAY", "TRFY")
			.Add("TRFCWY", "TRFY")
			.Add("TRFFCWY", "TRFY")
			.Add("TRFFWY", "TRFY")
			.Add("TRFWY", "TRFY")
			.Add("TRFY", "TRFY")
			.Add("TR", "TRL")
			.Add("TRAIL", "TRL")
			.Add("TRL-R", "TRAIL")
			.Add("TRAILS", "TRL")
			.Add("TRL", "TRL")
			.Add("TRLS", "TRL")
			.Add("THROUGHWAY", "TRWY")
			.Add("TRWY-R", "THROUGHWAY")
			.Add("THROUGHWY", "TRWY")
			.Add("THRUWAY", "TRWY")
			.Add("THRUWY", "TRWY")
			.Add("THRWAY", "TRWY")
			.Add("THRWY", "TRWY")
			.Add("THWY", "TRWY")
			.Add("TRWY", "TRWY")
			.Add("TUNEL", "TUNL")
			.Add("TUNL", "TUNL")
			.Add("TUNLS", "TUNL")
			.Add("TUNNEL", "TUNL")
			.Add("TUNL-R", "TUNNEL")
			.Add("TUNNELS", "TUNL")
			.Add("TUNNL", "TUNL")
			.Add("UN", "UN")
			.Add("UNION", "UN")
			.Add("UN-R", "UNION")
			.Add("UNIONS", "UNS")
			.Add("UNS-R", "UNIONS")
			.Add("UNS", "UNS")
			.Add("UDRPS", "UPAS")
			.Add("UNDERPAS", "UPAS")
			.Add("UNDERPASS", "UPAS")
			.Add("UPAS-R", "UNDERPASS")
			.Add("UNDERPS", "UPAS")
			.Add("UNDRPAS", "UPAS")
			.Add("UNDRPS", "UPAS")
			.Add("UPAS", "UPAS")
			.Add("VDCT", "VIA")
			.Add("VIA", "VIA")
			.Add("VIADCT", "VIA")
			.Add("VIADUCT", "VIA")
			.Add("VIA-R", "VIADUCT")
			.Add("VIS", "VIS")
			.Add("VIST", "VIS")
			.Add("VISTA", "VIS")
			.Add("VIS-R", "VISTA")
			.Add("VST", "VIS")
			.Add("VSTA", "VIS")
			.Add("VILLE", "VL")
			.Add("VL-R", "VILLE")
			.Add("VL", "VL")
			.Add("VILG", "VLG")
			.Add("VILL", "VLG")
			.Add("VILLAG", "VLG")
			.Add("VILLAGE", "VLG")
			.Add("VLG-R", "VILLAGE")
			.Add("VILLG", "VLG")
			.Add("VILLIAGE", "VLG")
			.Add("VLG", "VLG")
			.Add("VILGS", "VLGS")
			.Add("VILLAGES", "VLGS")
			.Add("VLGS-R", "VILLAGES")
			.Add("VLGS", "VLGS")
			.Add("VALLEY", "VLY")
			.Add("VLY-R", "VALLEY")
			.Add("VALLY", "VLY")
			.Add("VALY", "VLY")
			.Add("VLLY", "VLY")
			.Add("VLY", "VLY")
			.Add("VALLEYS", "VLYS")
			.Add("VLYS-R", "VALLEYS")
			.Add("VLYS", "VLYS")
			.Add("VIEW", "VW")
			.Add("VW-R", "VIEW")
			.Add("VW", "VW")
			.Add("VIEWS", "VWS")
			.Add("VWS-R", "VIEWS")
			.Add("VWS", "VWS")
			.Add("WALK", "WALK")
			.Add("WALK-R", "WALK")
			.Add("WALKS", "WALK")
			.Add("WLK", "WALK")
			.Add("WALL", "WALL")
			.Add("WALL-R", "WALL")
			.Add("WAY", "WAY")
			.Add("WAY-R", "WAY")
			.Add("WY", "WAY")
			.Add("WAYS", "WAYS")
			.Add("WAYS-R", "WAYS")
			.Add("WEL", "WL")
			.Add("WELL", "WL")
			.Add("WL-R", "WELL")
			.Add("WL", "WL")
			.Add("WELLS", "WLS")
			.Add("WLS-R", "WELLS")
			.Add("WELS", "WLS")
			.Add("WLS", "WLS")
			.Add("CROSING", "XING")
			.Add("CROSNG", "XING")
			.Add("CROSSING", "XING")
			.Add("XING-R", "CROSSING")
			.Add("CRSING", "XING")
			.Add("CRSNG", "XING")
			.Add("CRSSING", "XING")
			.Add("CRSSNG", "XING")
			.Add("XING", "XING")
			.Add("CROSRD", "XRD")
			.Add("CROSSRD", "XRD")
			.Add("CROSSROAD", "XRD")
			.Add("XRD-R", "CROSSROAD")
			.Add("CRSRD", "XRD")
			.Add("XRD", "XRD")
			.Add("XROAD", "XRD")
		End With

		With suffixSimiles
			.Add("LA", "LA")
			.Add("ST", "SAINT")
			.Add("VIA", "VIA")
		End With
	End Sub

	''' <summary>
	''' Formats a Delivery Address Line according to the United States Postal
	''' Service's Addressing Standards
	''' </summary>
	''' <remarks>
	''' <para>
	''' This comes in VERY handy when searching for records by address.
	''' Let's say a data entry person put an address in as
	''' "Two N Boulevard."  Later, someone else searches for them using
	''' "2 North Blvd."  Unfortunately, that query won't find them.  Such
	''' problems are averted by using this method before storing and
	''' searching for data.
	''' </para>
	''' <para>
	''' Standardization can also help obtain lower bulk mailing rates.
	''' </para>
	''' <para>
	''' Based upon USPS Publication 28, November 1997.
	''' </para>
	''' <para>
	''' http://pe.usps.gov/cpim/ftp/pubs/Pub28/pub28.pdf
	''' </para>
	''' </remarks>
	''' <param name="address">the address to be converted</param>
	''' <returns>the cleaned up address</returns>
	Public Function AddressLineStandardization(ByVal address As String) As String
		Dim parts() As String
		Dim atom() As String
		Dim rural_alternatives As String
		Dim highway_alternatives As String
		Dim mtch As Match
		Dim prior_one As Integer
		Dim next_one As Integer
		Dim id As Integer
		Dim suff As Integer
		Dim count As Integer


		If Trim(address) = "" Then
			Return ""
		End If

		'
		' General input sanitization.
		'

		address = UCase(address)

		' Replace bogus characters with spaces.
		address = Regex.Replace(address, "[^A-Z0-9 /#.-]", " ")

		' Remove starting and ending spaces.
		address = Trim(address)

		' Remove periods from ends.
		address = Regex.Replace(address, "\.$", "")

		' Add spaces around hash marks to simplify later processing.
		address = address.Replace("#", " # ")

		' Remove duplicate separators and spacing around separators,
		' simplifying the next few steps.
		address = Regex.Replace(address, " *([/.-])+ *", "$1")

		' Remove dashes between numberic/non-numerics combinations
		' at ends of lines (for apartment numbers "32-D" -> "32D").
		address = Regex.Replace(address, "(?<=[0-9])-(?=[^0-9]+$)", "")
		address = Regex.Replace(address, "(?<=[^0-9])-(?=[0-9]+$)", "")

		' Replace remaining separators with spaces.
		address = Regex.Replace(address, "(?<=[^0-9])[/.-](?=[^0-9])", " ")
		address = Regex.Replace(address, "(?<=[0-9])[/.-](?=[^0-9])", " ")
		address = Regex.Replace(address, "(?<=[^0-9])[/.-](?=[0-9])", " ")

		' Remove duplilcate spaces.
		address = Regex.Replace(address, "\s+", " ")

		' Remove hash marks where possible.
		mtch = Regex.Match(address, "(.+ )([A-Z]+) #( .+)")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If identifiers.ContainsKey(atom(2)) Then
				address = atom(1) & atom(2) & atom(3)
			End If
		End If

		address = Trim(address)

		If address = "" Then
			Return ""
		End If

		' Convert numeric words to integers.
		parts = Split(address)
		For key As Integer = 0 To UBound(parts)
			If numbers.ContainsKey(parts(key)) Then
				parts(key) = numbers(parts(key))
			End If
		Next
		address = Join(parts)

		address = Regex.Replace(address, " ([0-9]+)(ST|ND|RD|TH)? ?(?>FLOOR|FLR|FL)(?! [0-9])", " FL $1")
		address = Regex.Replace(address, "(NORTH|SOUTH) (EAST|WEST)", "$1$2")

		'
		' Check for special addresses.
		'

		rural_alternatives = "RR|RFD ROUTE|RURAL ROUTE|RURAL RTE|RURAL RT|RURAL DELIVERY|RD ROUTE|RD RTE|RD RT"
		mtch = Regex.Match(address, "^(" & rural_alternatives & ") ?([0-9]+)([A-Z #]+)([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			Return "RR " & atom(2) & " BOX " & atom(4)
		End If

		mtch = Regex.Match(address, "^(BOX|BX)([ #]*)([0-9A-Z]+) (" & rural_alternatives & ") ?([0-9]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			Return "RR " & atom(5) & " BOX " & atom(3)
		End If

		mtch = Regex.Match(address, "^((((POST|P) ?(OFFICE|O) ?)?(BOX|BX|B) |(POST|P) ?(OFFICE|O) ?)|FIRM CALLER|CALLER|BIN|LOCKBOX|DRAWER)( ?(# )*)([0-9A-Z-]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			Return "PO BOX " & atom(11)
		End If

		highway_alternatives = "HIGHWAY|HIGHWY|HIWAY|HIWY|HWAY|HWY|HYGHWAY|HYWAY|HYWY"
		mtch = Regex.Match(address, "^([0-9A-Z.-]+ ?[0-9/]* ?)(.*)( CNTY| COUNTY) (" & highway_alternatives & ")( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If states.ContainsKey(atom(2)) Then
				atom(2) = states(atom(2))
			End If
			If identifiers.ContainsKey(atom(6)) Then
				atom(6) = identifiers(atom(6))
				atom(7) = atom(7).Replace(" #", "")
				Return atom(1) & atom(2) & " COUNTY HWY " & atom(6) & atom(7)
			End If
			Return atom(1) & atom(2) & " COUNTY HIGHWAY " & atom(6) & getEolAbbr(atom(7))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ ?[0-9/]* ?)(.*)( CR |( CNTY| COUNTY) (ROAD|RD))( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If states.ContainsKey(atom(2)) Then
				atom(2) = states(atom(2))
			End If
			If identifiers.ContainsKey(atom(7)) Then
				atom(7) = identifiers(atom(7))
				atom(8) = atom(8).Replace(" #", "")
				Return atom(1) & atom(2) & " COUNTY RD " & atom(7) & atom(8)
			End If
			Return atom(1) & atom(2) & " COUNTY ROAD " & atom(7) & getEolAbbr(atom(8))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ ?[0-9/]* ?)(.*)( SR|( STATE| ST) (ROAD|RD))( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If states.ContainsKey(atom(2)) Then
				atom(2) = states(atom(2))
			End If
			If identifiers.ContainsKey(atom(7)) Then
				atom(7) = identifiers(atom(7))
				atom(8) = atom(8).Replace(" #", "")
				Return atom(1) & atom(2) & " STATE RD " & atom(7) & atom(8)
			End If
			Return atom(1) & atom(2) & " STATE ROAD " & atom(7) & getEolAbbr(atom(8))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ ?[0-9/]* ?)(.*)( STATE| ST) (ROUTE|RTE|RT)( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If states.ContainsKey(atom(2)) Then
				atom(2) = states(atom(2))
			End If
			If identifiers.ContainsKey(atom(6)) Then
				atom(6) = identifiers(atom(6))
				atom(7) = atom(7).Replace(" #", "")
				Return atom(1) & atom(2) & " STATE RTE " & atom(6) & atom(7)
			End If
			Return atom(1) & atom(2) & " STATE ROUTE " & atom(6) & getEolAbbr(atom(7))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ [0-9/]* ?)(INTERSTATE|INTRST|INT|I) ?(" & highway_alternatives & "|H)? ?([0-9]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			atom(5) = atom(5).Replace(" BYP ", " BYPASS ")
			Return atom(1) & "INTERSTATE " & atom(4) & getEolAbbr(atom(5))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ ?[0-9/]* ?)(.*)( STATE| ST) (" & highway_alternatives & ")( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If states.ContainsKey(atom(2)) Then
				atom(2) = states(atom(2))
			End If
			If identifiers.ContainsKey(atom(6)) Then
				atom(6) = identifiers(atom(6))
				atom(7) = atom(7).Replace(" #", "")
				Return atom(1) & atom(2) & " STATE HWY " & atom(6) & atom(7)
			End If
			Return atom(1) & atom(2) & " STATE HIGHWAY " & atom(6) & getEolAbbr(atom(7))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ ?[0-9/]* ?)(.*)( US| U S|UNITED STATES) (" & highway_alternatives & ")( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If states.ContainsKey(atom(2)) Then
				atom(2) = states(atom(2))
			End If
			If identifiers.ContainsKey(atom(6)) Then
				atom(6) = identifiers(atom(6))
				atom(7) = atom(7).Replace(" #", "")
				Return atom(1) & atom(2) & " US HWY " & atom(6) & atom(7)
			End If
			Return atom(1) & atom(2) & " US HIGHWAY " & atom(6) & getEolAbbr(atom(7))
		End If

		mtch = Regex.Match(address, "^((" & highway_alternatives & "|H) ?(CONTRACT|C)|STAR) ?(ROUTE|RTE|RT|R)?( NO | # | )?([0-9]+) ?([A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			Return "HC " & atom(6) & " BOX" & getEolAbbr(atom(8))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z.-]+ [0-9/]* ?)(RANCH )(ROAD|RD)( NO | # | )?([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			If identifiers.ContainsKey(atom(5)) Then
				atom(5) = identifiers(atom(5))
				atom(6) = atom(6).Replace(" #", "")
				Return atom(1) & "RANCH RD " & atom(5) & atom(6)
			End If
			Return atom(1) & "RANCH ROAD " & atom(5) & getEolAbbr(atom(6))
		End If

		address = Regex.Replace(address, "^([0-9A-Z.-]+) ([0-9][/][0-9])", "$1%$2")

		mtch = Regex.Match(address, "^([0-9A-Z/%.-]+ )(ROAD|RD)([A-Z #]+)([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			atom(1) = atom(1).Replace("%", " ")
			Return atom(1) & "ROAD " & atom(4) & getEolAbbr(atom(5))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z/%.-]+ )(ROUTE|RTE|RT)([A-Z #]+)([0-9A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			atom(1) = atom(1).Replace("%", " ")
			Return atom(1) & "ROUTE " & atom(4) & getEolAbbr(atom(5))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z/%.-]+ )(AVENUE|AVENU|AVNUE|AVEN|AVN|AVE|AV) ([A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			atom(1) = atom(1).Replace("%", " ")
			Return atom(1) & "AVENUE " & atom(3) & getEolAbbr(atom(4))
		End If

		mtch = Regex.Match(address, "^([0-9A-Z/%.-]+ )(BOULEVARD|BOULV|BOUL|BLVD) ([A-Z]+)(.*)$")
		If mtch.Success Then
			atom = convertGroupsToArray(mtch)
			atom(1) = atom(1).Replace("%", " ")
			Return atom(1) & "BOULEVARD" & getEolAbbr(atom(3) & atom(4))
		End If

		'
		' Handle normal addresses.
		'

		parts = Split(address)
		count = UBound(parts)
		Dim out(count) As String
		suff = 0
		id = 0

		For counter As Integer = count To 0 Step -1
			out(counter) = parts(counter)

			If suffixes.ContainsKey(parts(counter)) Then
				If suff = 0 Then
					' The first suffix (from the right).

					If UBound(out) >= counter + 1 AndAlso UBound(out) >= counter + 2 Then
						Select Case out(counter + 1) & " " & out(counter + 2)
							Case "EAST W", "WEST E", "NORTH S", "SOUTH N"
								' Already set.
							Case Else
								out(counter) = suffixes(parts(counter))
						End Select
					Else
						out(counter) = suffixes(parts(counter))
					End If

					If counter = count Then
						id = id + 1
					End If
				Else
					' A subsequent suffix, display as full word,
					' but could be a name (ie: LA, SAINT or VIA).

					If suffixSimiles.ContainsKey(parts(counter)) AndAlso _
					suffixes.ContainsKey(out(counter + 1)) = False Then
						out(counter) = suffixSimiles(parts(counter))
					Else
						out(counter) = suffixes(parts(counter))
						out(counter) = suffixes(out(counter) & "-R")
					End If
				End If

				suff = suff + 1

			ElseIf identifiers.ContainsKey(parts(counter)) Then
				out(counter) = identifiers(parts(counter))
				If suff > 0 Then
					out(counter) = identifiers(out(counter) & "-R")
				End If
				id = id + 1

			ElseIf directionals.ContainsKey(parts(counter)) Then
				prior_one = counter - 1
				next_one = counter + 1
				If count >= next_one AndAlso _
				suffixes.ContainsKey(parts(next_one)) Then
					out(counter) = directionals(parts(counter))
					If suff <= 1 Then
						out(counter) = directionals(out(counter) & "-R")
					End If
				ElseIf counter > 2 AndAlso _
				UBound(parts) >= next_one AndAlso _
				directionals.ContainsKey(parts(next_one)) Then
					' Already set.
				ElseIf counter = 2 AndAlso _
				directionals.ContainsKey(parts(prior_one)) Then
					' Already set.
				Else
					out(counter) = directionals(parts(counter))
				End If

				If counter = count Then
					id = 1
				End If
			ElseIf (Regex.IsMatch(parts(counter), "^[0-9]+$")) AndAlso _
			(counter > 0) AndAlso _
			(counter < count) Then
				If suff > 0 Then
					Select Case Right(parts(counter), 2)
						Case "11", "12", "13"
							out(counter) = parts(counter) & "TH"
						Case Else
							Select Case Right(parts(counter), 1)
								Case "1"
									out(counter) = parts(counter) & "ST"
								Case "2"
									out(counter) = parts(counter) & "ND"
								Case "3"
									out(counter) = parts(counter) & "RD"
								Case Else
									out(counter) = parts(counter) & "TH"
							End Select
					End Select
				End If
			End If
		Next

		out(0) = out(0).Replace("%", " ")
		Return Trim(Join(out))
	End Function

	''' <summary>
	''' Produces an array of strings from regular expression subpattern matches
	''' </summary>
	''' <param name="mtch">the regular expression Match object</param>
	''' <returns>the array of matched strings</returns>
	Private Function convertGroupsToArray(ByVal mtch As Match) As String()
		Dim counter As Integer = 0
		Dim out(mtch.Groups.Count) As String

		For Each grp As Group In mtch.Groups
			out(counter) = grp.Value
			counter = counter + 1
		Next

		Return out
	End Function

	''' <summary>
	''' Implement abbreviations for words at the ends of certain address lines
	''' </summary>
	''' <param name="input">the address fragments to be analyzed</param>
	''' <returns>the cleaned up string</returns>
	Private Function getEolAbbr(ByVal input As String) As String
		Dim suff As Integer
		Dim id As Integer
		Dim parts() As String
		Dim count As Integer

		suff = 0
		id = 0
		parts = Split(input)
		count = UBound(parts)
		Dim out(count) As String

		If count = 0 Then
			Return ""
		End If

		For counter As Integer = count To 0 Step -1
			If suffixes.ContainsKey(parts(counter)) Then
				If suff = 0 Then
					out(counter) = suffixes(parts(counter))
					suff = suff + 1
					If counter = count Then
						id = 1
					End If
				Else
					out(counter) = parts(counter)
				End If
			ElseIf identifiers.ContainsKey(parts(counter)) Then
				out(counter) = identifiers(parts(counter))
				id = 1
			ElseIf directionals.ContainsKey(parts(counter)) Then
				out(counter) = directionals(parts(counter))
				If counter = count Then
					id = 1
				End If
			Else
				out(counter) = parts(counter)
			End If
		Next

		Return " " & Trim(Join(out))
	End Function

	''' <summary>
	''' Destructor
	''' </summary>
	Protected Overrides Sub Finalize()
		MyBase.Finalize()
	End Sub
End Class
