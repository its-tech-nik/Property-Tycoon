INSERT INTO GameTable (
	gameNo, game_name, time_, date_, trading) 
	VALUES (1, "test", time('now'), date('now'), 1);

INSERT INTO DevProperties (
	tileNo, prop_name, group_, can_be_bought, cost, undeveloped_rent, rent_1, rent_2, rent_3, rent_4, rent_5)
	VALUES 
	(2,"Crapper Street","Brown",1, 0,60,2,10,30,90,160,250),
	(4,"Gangsters Paradise","Brown",1, 0,60,4,20,60,180,320,450),
	(7,"Weeping Angel","Blue",1, 0,100,6,30,90,270,400,550),
	(9,"Potts Avenue","Blue",1, 0,100,6,30,90,270,400,550),
	(10,"Nardole Drive","Blue",1, 0,120,8,40,100,300,450,600),
	(12,"Skywalker Drive","Purple",1, 0,140,10,50,150,450,625,750),
	(14,"Wookie Hole","Purple",1, 0,140,10,50,150,450,625,750),
	(15,"Rey Lane","Purple",1, 0,160,12,60,180,500,700,900),
	(17,"Cooper Drive","Orange",1, 0,180,14,70,200,550,750,950),
	(19,"Wolowitz Street","Orange",1, 0,180,14,70,200,550,750,950),
	(20,"Penny Lane","Orange",1, 0,200,16,80,220,600,800,1000),
	(22,"Yue Fei Square","Red",1, 0,220,18,90,250,700,875,1050),
	(24,"Mulan Rouge","Red",1, 0,220,18,90,250,700,875,1050),
	(25,"Han Xin Gardens","Red",1, 0,240,20,100,300,750,925,1100),
	(27,"Kirk Close","Yellow",1, 0,260,22,110,330,800,975,1150),
	(28,"Picard Avenue","Yellow",1, 0,260,22,110,330,800,975,1150),
	(30,"Crusher Creek","Yellow",1, 0,280,22,120,360,850,1025,1200),
	(32,"Sirat Mews","Green",1, 0,300,26,130,390,900,1100,1275),
	(33,"Ghengis Crescent","Green",1, 0,300,26,130,390,900,1100,1275),
	(35,"Ibis Close","Green",1, 0,320,28,150,450,1000,1200,1400),
	(38,"Hawking Way","Deep blue",1, 0,350,35,175,500,1100,1300,1500),
	(40,"Turing Heights","Deep blue",1, 0,400,50,200,600,1400,1700,2000);

INSERT INTO Stations (
	tileNo, prop_name, group_, can_be_bought, cost, rent1_St, rent2_St, rent3_St, rent4_St)
	VALUES
	(6,"Brighton Station","Station",1, 0,200,25,50,100,200),
	(16,"Hove Station","Station",1, 0,200,25,50,100,200),
	(26,"Falmer Station","Station",1, 0,200,25,50,100,200),
	(36,"Lewes Station","Station",1, 0,200,25,50,100,200);

INSERT INTO Utilities (
	tileNo, prop_name, group_, can_be_bought, cost, rent1_Ut, rent2_Ut)
	VALUES
	(13, "Tesla Power Co", "Utilities", 1, 0, 150, 4, 10), 
	(29, "Edison Water", "Utilities", 1, 0, 150, 4, 10);

INSERT INTO nonProperties (
	tileNo, prop_name, group_, can_be_bought, cost)
	VALUES
	(1,"Go","Game",0,-200),
	(3,"Pot Luck","PL Card",0,0),
	(5,"Income Tax","Tax",0,200),
	(8,"Opportunity Knocks","OK Card",0,0),
	(11,"Jail/Just visiting","Jail",0,50),
	(18,"Pot Luck","PL Card",0,0),
	(21,"Free Parking","Game",0,0),
	(23,"Opportunity Knocks","OK Card",0,0),
	(31,"Go to Jail","Go to jail",0,0),
	(34,"Pot Luck","PL Card",0,0),
	(37,"Opportunity Knocks","OK Card",0,0),
	(39,"Super Tax","Tax",0,100);



INSERT INTO Players (
	player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, fname, lname)
	VALUES
	("BANK", 1, 0, "BANK", 10000, 0, "KINGSLEY", "SAGE");

INSERT INTO Account (
	player_id, password_)
	VALUES
	("Michael1", 12345);

INSERT INTO devAssets (
	assetNo, developed, player_id)
	VALUES
	(2,0,"BANK"),
	(4,0,"BANK"),
	(7,0,"BANK"),
	(9,0,"BANK"),
	(10,0,"BANK"),
	(12,0,"BANK"),
	(14,0,"BANK"),
	(15,0,"BANK"),
	(17,0,"BANK"),
	(19,0,"BANK"),
	(20,0,"BANK"),
	(22,0,"BANK"),
	(24,0,"BANK"),
	(25,0,"BANK"),
	(27,0,"BANK"),
	(28,0,"BANK"),
	(30,0,"BANK"),
	(32,0,"BANK"),
	(33,0,"BANK"),
	(35,0,"BANK"),
	(38,0,"BANK"),
	(40,0,"BANK");

INSERT INTO StationAssets (
	assetNo, type, player_id)
	VALUES
	(6,0,"BANK"),
	(16,0,"BANK"),
	(26,0,"BANK"),
	(36,0,"BANK");

INSERT INTO UtilitiesAssets (
	assetNo, type, player_id)
	VALUES
	(13,0,"BANK"),
	(29,0,"BANK");

/*INSERT INTO Tiles (
	tileNo, gameNo)
	VALUES
	(0, 1),
	(1,	1),
	(2,	1),
	(3,	1),
	(4,	1),
	(5,	1),
	(6,	1),
	(7,	1),
	(8,	1),
	(9,	1),
	(10,1),
	(11,1),
	(12,1),
	(13,1),
	(14,1),
	(15,1),
	(16,1),
	(17,1),
	(18,1),
	(19,1),
	(20,1),
	(21,1),
	(22,1),
	(23,1),
	(24,1),
	(25,1),
	(26,1),
	(27,1),
	(28,1),
	(29,1),
	(30,1),
	(31,1),
	(32,1),
	(33,1),
	(34,1),
	(35,1),
	(36,1),
	(37,1),
	(38,1),
	(39,1),
	(40,1)
	*/
