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

INSERT INTO NonProperties (
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

INSERT INTO Players (
	player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, bot, player_name)
	VALUES
	("BANK", 1, -1, "NONE", 10000, 0, 0, "KINGSLEY");

INSERT INTO Account (
	player_id, password_)
	VALUES
	("Michael1", 12345);

INSERT INTO devAssets (
	assetNo, developed, player_id, gameNo, mortgaged)

	VALUES
	(2,0,"BANK", 0),
	(4,0,"BANK", 0),
	(7,0,"BANK", 0),
	(9,0,"BANK", 0),
	(10,0,"BANK", 0),
	(12,0,"BANK", 0),
	(14,0,"BANK", 0),
	(15,0,"BANK", 0),
	(17,0,"BANK", 0),
	(19,0,"BANK", 0),
	(20,0,"BANK", 0),
	(22,0,"BANK", 0),
	(24,0,"BANK", 0),
	(25,0,"BANK", 0),
	(27,0,"BANK", 0),
	(28,0,"BANK", 0),
	(30,0,"BANK", 0),
	(32,0,"BANK", 0),
	(33,0,"BANK", 0),
	(35,0,"BANK", 0),
	(38,0,"BANK", 0),
	(40,0,"BANK", 0);

INSERT INTO StationAssets (
	assetNo, type, player_id, gameNo, mortgaged)
	VALUES
	(6,0,"BANK", 0),
	(16,0,"BANK", 0),
	(26,0,"BANK", 0),
	(36,0,"BANK", 0);

INSERT INTO UtilitiesAssets (
	assetNo, type, player_id, gameNo, mortgaged)
	VALUES
	(13,0,"BANK", 0),
	(29,0,"BANK", 0);

