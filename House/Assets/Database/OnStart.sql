INSERT INTO GameTable (
	gameNo, time_, date_, trading) 
	VALUES (1, time('now'), 1);

INSERT INTO DevProperties (
	tileNo, prop_name, group_, cost, undeveloped_rent, undeveloped_rentAll, rent_1, rent_2, rent_3, rent_4, rent_5)
	VALUES 
	(2,"Crapper Street","Brown",60,2,4,10,30,90,160,250),
	(4,"Gangsters Paradise","Brown",60,4,8,20,60,180,320,450),
	(7,"Weeping Angel","Blue",100,6,12,30,90,270,400,550),
	(9,"Potts Avenue","Blue",100,6,12,30,90,270,400,550),
	(10,"Nardole Drive","Blue",120,8,16,40,100,300,450,600),
	(12,"Skywalker Drive","Purple",140,10,20,50,150,450,625,750),
	(14,"Wookie Hole","Purple",140,10,20,50,150,450,625,750),
	(15,"Rey Lane","Purple",160,12,24,60,180,500,700,900),
	(17,"Cooper Drive","Orange",180,14,28,70,200,550,750,950),
	(19,"Wolowitz Street","Orange",180,14,28,70,200,550,750,950),
	(20,"Penny Lane","Orange",200,16,32,80,220,600,800,1000),
	(22,"Yue Fei Square","Red",220,18,36,90,250,700,875,1050),
	(24,"Mulan Rouge","Red",220,18,36,90,250,700,875,1050),
	(25,"Han Xin Gardens","Red",240,20,40,100,300,750,925,1100),
	(27,"Kirk Close","Yellow",260,22,44,110,330,800,975,1150),
	(28,"Picard Avenue","Yellow",260,22,44,110,330,800,975,1150),
	(30,"Crusher Creek","Yellow",280,22,44,120,360,850,1025,1200),
	(32,"Sirat Mews","Green",300,26,52,130,390,900,1100,1275),
	(33,"Ghengis Crescent","Green",300,26,52,130,390,900,1100,1275),
	(35,"Ibis Close","Green",320,28,56,150,450,1000,1200,1400),
	(38,"Hawking Way","Deep blue",350,35,70,175,500,1100,1300,1500),
	(40,"Turing Heights","Deep blue",400,50,100,200,600,1400,1700,2000);

INSERT INTO Stations (
	tileNo, prop_name, group_, cost, rent1_St, rent2_St, rent3_St, rent4_St)
	VALUES
	(6,"Brighton Station","Station",200,25,50,100,200),
	(16,"Hove Station","Station",200,25,50,100,200),
	(26,"Falmer Station","Station",200,25,50,100,200),
	(36,"Lewes Station","Station",200,25,50,100,200);

INSERT INTO Utilities (
	tileNo, prop_name, group_, cost, rent1_Ut, rent2_Ut)
	VALUES
	(13, "Tesla Power Co", "Utilities", 150, 4, 10), 
	(29, "Edison Water", "Utilities", 150, 4, 10);

INSERT INTO nonProperties (
	tileNo, prop_name, group_, cost)
	VALUES
	(1,"Go","Game",-200),
	(3,"Pot Luck","PL Card",0),
	(5,"Income Tax","Tax",200),
	(8,"Opportunity Knocks","OK Card",0),
	(11,"Jail/Just visiting","Jail",50),
	(18,"Pot Luck","PL Card",0),
	(21,"Free Parking","Game",0),
	(23,"Opportunity Knocks","OK Card",0),
	(31,"Go to Jail","Go to jail",0),
	(34,"Pot Luck","PL Card",0),
	(37,"Opportunity Knocks","OK Card",0),
	(39,"Super Tax","Tax",100);


INSERT INTO Players 
	(player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, bot, jail, player_name)
	SELECT "BANK", gameNo ,  0, "BANK", 10000, 2, 0, 0, "KINGSLEY SAGE"
	FROM GameTable ORDER BY gameNo DESC LIMIT 1

INSERT INTO Account (
	player_id, password_)
	VALUES
	("Michael1", 12345);

INSERT INTO devAssets (
	assetNo, developed, player_id, gameNo, mortgaged)
	SELECT
	(2,0,"BANK", player_id, gameNo, 0),
	(4,0,"BANK",,,0),
	(7,0,"BANK",,,0),
	(9,0,"BANK",,,0),
	(10,0,"BANK",,,0),
	(12,0,"BANK",,,0),
	(14,0,"BANK",,,0),
	(15,0,"BANK",,,0),
	(17,0,"BANK",,,0),
	(19,0,"BANK",,,0),
	(20,0,"BANK",,,0),
	(22,0,"BANK",,,0),
	(24,0,"BANK",,,0),
	(25,0,"BANK",,,0),
	(27,0,"BANK",,,0),
	(28,0,"BANK",,,0),
	(30,0,"BANK",,,0),
	(32,0,"BANK",,,0),
	(33,0,"BANK",,,0),
	(35,0,"BANK",,,0),
	(38,0,"BANK",,,0),
	(40,0,"BANK",,,0)
	FROM Players WHERE gameNo = SELECT gameNo ;

INSERT INTO StationAssets (
	assetNo, type, player_id, gameNo, mortgaged)
	SELECT 
	(6,0,"BANK",,,0),
	(16,0,"BANK",,,0),
	(26,0,"BANK",,,0),
	(36,0,"BANK",,,0);

INSERT INTO UtilitiesAssets (
	assetNo, type, player_id)
	SELECT 
	(13,0,"BANK",,,0),
	(29,0,"BANK",,,0);

INSERT INTO PotLuck (
	cardNo, description, category, cost, moveToLocation, receiver)
	VALUES
		(0,"Pay a £10 fine or take opportunity knocks","Choice",10,NULL,"FreeParking"),
		(1,"Go back to Crapper Street","GoBackwards",0,2,NULL),
		(2,"Advance to go","GoForward",0,1,NULL),
		(3,"Get out of jail free","GetOutOfJailFree",0,NULL,NULL),
		(4,"Go to jail. Do not pass GO, do not collect £200","Jail",0,31,NULL),
		(5,"Pay bill for text books of £100","PayBank",100,NULL,"BANK"),
		(6,"Mega late night taxi bill pay £50","PayBank",50,NULL,"BANK"),
		(7,"Pay insurance fee of £50","PayFreeParking",50,NULL,"FreeParking"),
		(8,"You inherit £100","ReceiveFromBank",-100,NULL,"playerId"),
		(9,"You have won 2nd prize in a beauty contest, collect £20","ReceiveFromBank",-20,NULL,"playerId"),
		(10,"Student loan refund. Collect £20","ReceiveFromBank",-20,NULL,"playerId"),
		(11,"Bank error in your favour. Collect £200","ReceiveFromBank",-200,NULL,"playerId"),
		(12,"From sale of Bitcoin you get £50","ReceiveFromBank",-50,NULL,"playerId"),
		(13,"Savings bond matures, collect £100","ReceiveFromBank",-100,NULL,"playerId"),
		(14,"Received interest on shares of £25","ReceiveFromBank",-25,NULL,"playerId"),
		(15,"It's your birthday. Collect £10 from each player","ReceiveFromOtherPlayers",-10,NULL,"playerId")

INSERT INTO OpportunityKnocks (
		cardNo, description, category, cost, moves, moveToLocation, receiver, houseCost, hotelCost)
	VALUES
		(0,"You are assessed for repairs, £40/house, £115/hotel","Repairs",0,0,NULL,"BANK",40,115),
		(1,"Advance to Turing Heights","GoBackwards",0,0,40,NULL,NULL,NULL),
		(2,"Advance to Han Xin Gardens. If you pass GO, collect £200","GoForward",0,0,25,NULL,NULL,NULL),
		(3,"Take a trip to Hove station. If you pass GO collect £200","GoForward",0,0,16,NULL,NULL,NULL),
		(4,"Advance to GO","GoForward",0,0,1,NULL,NULL,NULL),
		(5,"Advance to Skywalker Drive. If you pass GO collect £200","GoForward",0,0,12,NULL,NULL,NULL),
		(6,"Get out of jail free","GetOutOfJailFree",0,0,NULL,NULL,NULL,NULL),
		(7,"Go to jail. Do not pass GO, do not collect £200","Jail",0,0,31,NULL,NULL,NULL),
		(8,"Pay university fees of £150","Pay bank",150,0,NULL,"BANK",NULL,NULL),
		(9,"You are assessed for repairs, £25/house, £100/hotel","CalcPayToBank",0,0,NULL,"BANK",25,100),
		(10,"Fined £15 for speeding","PayFreeParking",15,0,NULL,"FreeParking",NULL,NULL),
		(11,"Drunk in charge of a skateboard. Fine £20","PayFreeParking",20,0,NULL,"FreeParking",NULL,NULL),
		(12,"Bank pays you divided of £50","ReceiveFromBank",-50,0,NULL,"playerId",NULL,NULL),
		(13,"You have won a lip sync battle. Collect £100","ReceiveFromBank",-100,0,NULL,"playerId",NULL,NULL),
		(14,"Loan matures, collect £150","ReceiveFromBank",-150,0,NULL,"playerId",NULL,NULL),
		(15,"Go back 3 spaces","GoBackwards",0,3,NULL,NULL,NULL,NULL)

SELECT * from DevProperties
UNION 
SELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, rent1_St AS rent_1, rent2_St AS rent_2,rent3_St AS rent_3, rent4_St AS rent_4, NULL AS rent_5
from Stations
UNION 
SELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, rent1_Ut AS rent_1, rent2_Ut AS rent_2,NULL AS rent_3, NULL AS rent_4, NULL AS rent_5
from Utilities
union
SELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, NULL AS rent_1, NULL AS rent_2,NULL AS rent_3, NULL AS rent_4, NULL AS rent_5
from NonProperties
ORDER BY tileNo

