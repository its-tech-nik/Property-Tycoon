using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;


public class DatabaseConnection : MonoBehaviour {

	private string connectionString;
	private int gameNo;
	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/PropertyTycoon.db";
		//createBoard();
		//newGame(1); //Needs input args
		//insertStaticData ();
		//insertCardData();

		//viewWallet("Bank");

		//createBoard();
		//newGame(true); //Needs input args
		//insertStaticData ();
		//insertCardData();
		//createPlayers (1500);
		//insertStartOwnership ();
		GetBoardData ();
	}

	// Update is called once per frame
	void Update () {

	}

	private void GetBoardData(){
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery = "SELECT * from DevProperties\nUNION \nSELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, rent1_St AS rent_1, rent2_St AS rent_2,rent3_St AS rent_3, rent4_St AS rent_4, NULL AS rent_5\nfrom Stations\nUNION \nSELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, rent1_Ut AS rent_1, rent2_Ut AS rent_2,NULL AS rent_3, NULL AS rent_4, NULL AS rent_5\nfrom Utilities\nunion\nSELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, NULL AS rent_1, NULL AS rent_2,NULL AS rent_3, NULL AS rent_4, NULL AS rent_5\nfrom NonProperties\nORDER BY tileNo";

				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Game.board [reader.GetInt16 (0) - 1] = new Tile (reader.GetString(1), reader.GetString(2), reader.GetInt16(3));
					}

					dbConnection.Close();
					reader.Close();
				}
			}
		}
	}

	private String GetDataString(String query){
		String result = "error";
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery = query;
				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{
						//Debug.Log(reader.ToString());
					}
					dbConnection.Close();
					reader.Close();
				}
			}
		}
		return result;
	}

	/*private void createPlayers(ArrayList players, int startAmount){
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			//Creates a database command
			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				//Creates a query for inserting the data

				string sqlQueryBank = String.Format("INSERT INTO Players(player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, bot, jail, player_name) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")","BANK", gameNo, 0, "BANK", 10000, 2, 0, 0, "KINGSLEY SAGE");

				dbCmd.CommandText = sqlQueryBank; //Gives the query to the commandtext
				dbCmd.ExecuteScalar(); //Executes the query

				string sqlQueryFreeParking = String.Format("INSERT INTO Players(player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, bot, jail, player_name) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")","FreeParking", gameNo, 0, "FreeParking", 10000, 0, 0, 0, "FreeParking");

				dbCmd.CommandText = sqlQueryFreeParking; //Gives the query to the commandtext

				foreach (Player player in players) {
					int playerId = player.playerId;
					int tokenLocation = player.location;
					String tokenShape = player.tokenShape;
					int wallet = player.wallet;
					String playerName = player.name;
					Boolean isBot = player.bot;
					Boolean isJail = player.jail;
					int jailFreeCard = player.getOutOfJailFreeCard;

					string sqlQueryEnterPlayer = String.Format("INSERT INTO Players(player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, bot, jail, player_name) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")",playerId, gameNo, tokenLocation, tokenShape, startAmount, jailFreeCard, isBot, isJail, playerName);
				}

				dbCmd.ExecuteScalar(); //Executes the query
				dbConnection.Close();//Closes the connection

			}
		}
	}*/

	private void createBoard(){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			//Opens the connection
			dbConnection.Open ();

			//Creates a database comment
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				//Creates a query for inserting the new score 
				string sqlQuery = String.Format ("CREATE TABLE GameTable (\n    gameNo    INTEGER PRIMARY KEY AUTOINCREMENT,\n    time_     TIME DEFAULT CURRENT_TIMESTAMP,\n    trading   BOOLEAN CHECK (trading IN (0, 1) ) NOT NULL\n);\n\n\t\n\nCREATE TABLE DevProperties (\n    tileNo INTEGER NOT NULL,\n    prop_name VARCHAR (50),\n    group_ VARCHAR (15),\n    cost INTEGER NOT NULL,\n    undeveloped_rent INTEGER NOT NULL,\n    undeveloped_rentAll INTEGER NOT NULL,\n    rent_1 INTEGER NOT NULL,\n    rent_2 INTEGER NOT NULL,\n    rent_3 INTEGER NOT NULL,\n    rent_4 INTEGER NOT NULL,\n    rent_5 INTEGER NOT NULL,\n    PRIMARY KEY \n        (tileNo)\n    );\n\n\t\n\nCREATE TABLE Stations (\n    tileNo   INTEGER,\n    prop_name VARCHAR(50),\n    group_ VARCHAR (15) NOT NULL DEFAULT \"Stations\",\n    cost INTEGER NOT NULL DEFAULT 200,\n    rent1_St INTEGER NOT NULL DEFAULT 25,\n    rent2_St INTEGER NOT NULL DEFAULT 50,\n    rent3_St INTEGER NOT NULL DEFAULT 100,\n    rent4_St INTEGER NOT NULL DEFAULT 200,\n    PRIMARY KEY \n        (tileNo)\n    );\n\n\t\n\n\nCREATE TABLE Utilities (\n    tileNo INTEGER,\n    prop_name VARCHAR(50),\n    group_ VARCHAR(50) NOT NULL DEFAULT \"Utilities\",\n    cost INTEGER,\n    rent1_Ut INTEGER DEFAULT 4,\n    rent2_Ut INTEGER DEFAULT 10,\n    PRIMARY KEY \n        (tileNo)  \n);\n\nCREATE TABLE NonProperties (\n    tileNo INTEGER,\n    prop_name VARCHAR(50),\n    group_ VARCHAR(50),\n    cost INTEGER,\n    PRIMARY KEY \n        (tileNo)\n    );\n\n\t\n\n\n\nCREATE TABLE Players (\n    player_id VARCHAR(50),\n    gameNo INTEGER,\n    token_loc INTEGER,\n    token_shape VARCHAR(50),\n    wallet INTEGER(50),  \n    get_out_of_jail_card INTEGER(50),\n    bot BOOLEAN,\n    jail BOOLEAN,\n    player_name VARCHAR(50),\n    PRIMARY KEY (\n        player_id, gameNo\n    ),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo)\n);\n\n\t\t\n\n\nCREATE TABLE Account (\n    player_id VARCHAR(50),\n    password_ VARCHAR (50),\n    PRIMARY KEY (\n        player_id\n    )\n);\n\n\n  \n\nCREATE TABLE devAssets (\n    assetNo   INTEGER,\n    developed INTEGER,\n    player_id INTEGER,\n    gameNo INTEGER,\n    mortgaged BOOLEAN,\n    FOREIGN KEY (\n        assetNo\n    )\n    REFERENCES DevProperties (tileNo),\n    FOREIGN KEY (\n        player_id\n    )\n    REFERENCES Players (player_id),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo) \n);\n\n   \n\nCREATE TABLE UtilitiesAssets (\n    assetNo INTEGER,\n    type VARCHAR(50),\n    player_id INTEGER,\n    gameNo INTEGER,\n    mortgaged BOOLEAN,\n    FOREIGN KEY (\n        assetNo\n    )\n    REFERENCES Utilities (tileNo),\n    FOREIGN KEY (\n        player_id\n    )\n    REFERENCES Players (player_id),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo)   \n);\n\nCREATE TABLE StationAssets (\n    assetNo INTEGER,\n    type VARCHAR(50),\n    player_id INTEGER,\n    gameNo INTEGER,\n    mortgaged BOOLEAN,\n    FOREIGN KEY (\n        assetNo\n    )\n    REFERENCES Stations (tileNo),\n    FOREIGN KEY (\n        player_id\n    )\n    REFERENCES Players (player_id),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo)\n    );\n\nCREATE TABLE OpportunityKnocks (\n    cardNo INTEGER,\n    description VARCHAR(255), \n    category VARCHAR(50), /*type of action*/\n    cost INTEGER, /*cost if there is one, else 0*/\n    moves INTEGER, /*how far needs to move, else 0 (will need to calculate if passes go)*/\n    moveToLocation INTEGER, /*the tileNo to move to else NULL (will need to calculate if passes go)*/\n    receiver VARCHAR(50), /*the receiver of the payment else NULL*/\n    houseCost INTEGER, /*for repairs, else null*/\n    hotelCost INTEGER /*for repairs, else null*/\n    );\n\nCREATE TABLE PotLuck (\n    cardNo INTEGER,\n    description VARCHAR(255), /*card description*/\n    category VARCHAR(50), /*type of action*/\n    cost INTEGER, /*cost if there is one, else 0*/\n    moveToLocation INTEGER, /*the tileNo to move to else NULL (will need to calculate if passes go)*/\n    receiver VARCHAR(50) /*the receiver of the payment else NULL*/\n    );\n");

				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext

				dbCmd.ExecuteScalar (); //Executes the query
				dbConnection.Close ();//Closes the connetion
			}
		}
	}

	private void newGame(int trading){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			//Opens the connection
			dbConnection.Open ();

			//Creates a database comment
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				//Creates a query for inserting the new game
				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
				dbCmd.ExecuteScalar (); //Executes the query
				dbConnection.Close ();//Closes the connetion
			}
		
		//Opens the connection
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				string sqlQuery1 = "select gameNo from GameTable ORDER BY gameNo DESC LIMIT 1";
				dbConnection.Open ();
				dbCmd.CommandText = sqlQuery1;
				using (IDataReader reader = dbCmd.ExecuteReader ()) {
					while (reader.Read ()) {
						gameNo = reader.GetInt32 (0);
					}
					reader.Close ();
					dbConnection.Close();//Closes the connection
				}
			}
		}
	}

	//	private ArrayList retreiveCards(){
	//		for (int i = 1; i < 16; i++) {
	//
	//		}
	//	}

		private int viewWallet(String playerId){
			using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
				dbConnection.Open();
	
				using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
					string sqlQuery = "select * from Players WHERE player_id = "+ playerId +" AND gameNo = " + gameNo;
					dbCmd.CommandText = sqlQuery;
					using(IDataReader reader = dbCmd.ExecuteReader())
					{
						while (reader.Read())
						{
							return reader.GetInt32(5);
						}
						dbConnection.Close();
						reader.Close();
					}
				}
			};
			return -1;
		}

	//	private void alterWallet(int change, String playerId ){
	//		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
	//			//Opens the connection
	//			dbConnection.Open ();
	//
	//			//Creates a database comment
	//			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
	//
	//				//Creates a query for inserting the new score
	//				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
	//				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
	//				dbCmd.ExecuteScalar (); //Executes the query
	//				dbConnection.Close ();//Closes the connetion
	//			}
	//		}
	//	}


	//	private void freeParking(String playerId){
	//		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
	//			//Opens the connection
	//			dbConnection.Open ();
	//
	//			//Creates a database comment
	//			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
	//
	//				//Creates a query for inserting the new score
	//				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
	//				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
	//				dbCmd.ExecuteScalar (); //Executes the query
	//				dbConnection.Close ();//Closes the connetion
	//			}
	//		}
	//	}


	//	private void changeOwner(String category, String playerId1, String playerId2){
	//		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
	//			//Opens the connection
	//			dbConnection.Open ();
	//
	//			//Creates a database comment
	//			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
	//
	//				//Creates a query for inserting the new score
	//				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
	//				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
	//				dbCmd.ExecuteScalar (); //Executes the query
	//				dbConnection.Close ();//Closes the connetion
	//			}
	//		}
	//	}


	//	private void makeMortgaged(int tileNo){
	//		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
	//			//Opens the connection
	//			dbConnection.Open ();
	//
	//			//Creates a database comment
	//			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
	//
	//				//Creates a query for inserting the new score
	//				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
	//				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
	//				dbCmd.ExecuteScalar (); //Executes the query
	//				dbConnection.Close ();//Closes the connetion
	//			}
	//		}
	//	}


	private Boolean checkMortgaged(int tileNo){
		Boolean mortgaged = false;
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery = "select * from ";
				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{
						mortgaged = reader.GetBoolean(0);

					}
					dbConnection.Close();
					reader.Close();
				}
			}
		}
		return mortgaged;
	}

	//	private void developProperty(int tileNo){
	//		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
	//			//Opens the connection
	//			dbConnection.Open ();
	//
	//			//Creates a database comment
	//			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
	//
	//				//Creates a query for inserting the new score
	//				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
	//				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
	//				dbCmd.ExecuteScalar (); //Executes the query
	//				dbConnection.Close ();//Closes the connetion
	//			}
	//		}
	//	}

	/* inner join static with asset, count player in assetNo group. */

	//	private int countProperty(String playerId, int tileNo, String tableName){
	//		int groupOwnership;
	//		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
	//			dbConnection.Open();
	//
	//			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
	//				string sqlQuery = "select count("+ playerId +") from SELECT * FROM "+tableName+" WHERE assetNo = select tileNo ";
	//				dbCmd.CommandText = sqlQuery;
	//				using(IDataReader reader = dbCmd.ExecuteReader())
	//				{
	//					while (reader.Read())
	//					{
	//						groupOwnership = reader.GetInt32(0);
	//
	//					}
	//					dbConnection.Close();
	//					reader.Close();
	//				}
	//			}
	//		}
	//		return groupOwnership;
	//	}

	// this doesn't need to run all the time.
	private void insertStaticData (){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			//Opens the connection
			dbConnection.Open ();

			//Creates a database comment
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				//Creates a query for inserting the new score
				string sqlQuery = String.Format ("INSERT INTO DevProperties (\n\ttileNo, prop_name, group_, cost, undeveloped_rent, undeveloped_rentAll, rent_1, rent_2, rent_3, rent_4, rent_5)\n\tVALUES \n\t(2,\"Crapper Street\",\"Brown\",60,2,4,10,30,90,160,250),\n\t(4,\"Gangsters Paradise\",\"Brown\",60,4,8,20,60,180,320,450),\n\t(7,\"Weeping Angel\",\"Blue\",100,6,12,30,90,270,400,550),\n\t(9,\"Potts Avenue\",\"Blue\",100,6,12,30,90,270,400,550),\n\t(10,\"Nardole Drive\",\"Blue\",120,8,16,40,100,300,450,600),\n\t(12,\"Skywalker Drive\",\"Purple\",140,10,20,50,150,450,625,750),\n\t(14,\"Wookie Hole\",\"Purple\",140,10,20,50,150,450,625,750),\n\t(15,\"Rey Lane\",\"Purple\",160,12,24,60,180,500,700,900),\n\t(17,\"Cooper Drive\",\"Orange\",180,14,28,70,200,550,750,950),\n\t(19,\"Wolowitz Street\",\"Orange\",180,14,28,70,200,550,750,950),\n\t(20,\"Penny Lane\",\"Orange\",200,16,32,80,220,600,800,1000),\n\t(22,\"Yue Fei Square\",\"Red\",220,18,36,90,250,700,875,1050),\n\t(24,\"Mulan Rouge\",\"Red\",220,18,36,90,250,700,875,1050),\n\t(25,\"Han Xin Gardens\",\"Red\",240,20,40,100,300,750,925,1100),\n\t(27,\"Kirk Close\",\"Yellow\",260,22,44,110,330,800,975,1150),\n\t(28,\"Picard Avenue\",\"Yellow\",260,22,44,110,330,800,975,1150),\n\t(30,\"Crusher Creek\",\"Yellow\",280,22,44,120,360,850,1025,1200),\n\t(32,\"Sirat Mews\",\"Green\",300,26,52,130,390,900,1100,1275),\n\t(33,\"Ghengis Crescent\",\"Green\",300,26,52,130,390,900,1100,1275),\n\t(35,\"Ibis Close\",\"Green\",320,28,56,150,450,1000,1200,1400),\n\t(38,\"Hawking Way\",\"Deep blue\",350,35,70,175,500,1100,1300,1500),\n\t(40,\"Turing Heights\",\"Deep blue\",400,50,100,200,600,1400,1700,2000);\n\nINSERT INTO Stations (\n\ttileNo, prop_name, group_, cost, rent1_St, rent2_St, rent3_St, rent4_St)\n\tVALUES\n\t(6,\"Brighton Station\",\"Station\",200,25,50,100,200),\n\t(16,\"Hove Station\",\"Station\",200,25,50,100,200),\n\t(26,\"Falmer Station\",\"Station\",200,25,50,100,200),\n\t(36,\"Lewes Station\",\"Station\",200,25,50,100,200);\n\nINSERT INTO Utilities (\n\ttileNo, prop_name, group_, cost, rent1_Ut, rent2_Ut)\n\tVALUES\n\t(13, \"Tesla Power Co\", \"Utilities\", 150, 4, 10), \n\t(29, \"Edison Water\", \"Utilities\", 150, 4, 10);\n\nINSERT INTO nonProperties (\n\ttileNo, prop_name, group_, cost)\n\tVALUES\n\t(1,\"Go\",\"Game\",-200),\n\t(3,\"Pot Luck\",\"PL Card\",0),\n\t(5,\"Income Tax\",\"Tax\",200),\n\t(8,\"Opportunity Knocks\",\"OK Card\",0),\n\t(11,\"Jail/Just visiting\",\"Jail\",50),\n\t(18,\"Pot Luck\",\"PL Card\",0),\n\t(21,\"Free Parking\",\"Game\",0),\n\t(23,\"Opportunity Knocks\",\"OK Card\",0),\n\t(31,\"Go to Jail\",\"Go to jail\",0),\n\t(34,\"Pot Luck\",\"PL Card\",0),\n\t(37,\"Opportunity Knocks\",\"OK Card\",0),\n\t(39,\"Super Tax\",\"Tax\",100);\n");
				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
				dbCmd.ExecuteScalar (); //Executes the query
				dbConnection.Close ();//Closes the connetion
			}
		}
	}

	// this doesn't need to run all the time.
	private void insertCardData(){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			//Opens the connection
			dbConnection.Open ();

			//Creates a database comment
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				//Creates a query for inserting the new score
				string sqlQueryPotLuck = String.Format ("INSERT INTO PotLuck (\n\tcardNo, description, category, cost, moveToLocation, receiver)\n\tVALUES\n\t\t(0,\"Pay a £10 fine or take opportunity knocks\",\"Choice\",10,NULL,\"FreeParking\"),\n\t\t(1,\"Go back to Crapper Street\",\"GoBackwards\",0,2,NULL),\n\t\t(2,\"Advance to go\",\"GoForward\",0,1,NULL),\n\t\t(3,\"Get out of jail free\",\"GetOutOfJailFree\",0,NULL,NULL),\n\t\t(4,\"Go to jail. Do not pass GO, do not collect £200\",\"Jail\",0,31,NULL),\n\t\t(5,\"Pay bill for text books of £100\",\"PayBank\",100,NULL,\"BANK\"),\n\t\t(6,\"Mega late night taxi bill pay £50\",\"PayBank\",50,NULL,\"BANK\"),\n\t\t(7,\"Pay insurance fee of £50\",\"PayFreeParking\",50,NULL,\"FreeParking\"),\n\t\t(8,\"You inherit £100\",\"ReceiveFromBank\",-100,NULL,\"playerId\"),\n\t\t(9,\"You have won 2nd prize in a beauty contest, collect £20\",\"ReceiveFromBank\",-20,NULL,\"playerId\"),\n\t\t(10,\"Student loan refund. Collect £20\",\"ReceiveFromBank\",-20,NULL,\"playerId\"),\n\t\t(11,\"Bank error in your favour. Collect £200\",\"ReceiveFromBank\",-200,NULL,\"playerId\"),\n\t\t(12,\"From sale of Bitcoin you get £50\",\"ReceiveFromBank\",-50,NULL,\"playerId\"),\n\t\t(13,\"Savings bond matures, collect £100\",\"ReceiveFromBank\",-100,NULL,\"playerId\"),\n\t\t(14,\"Received interest on shares of £25\",\"ReceiveFromBank\",-25,NULL,\"playerId\"),\n\t\t(15,\"It's your birthday. Collect £10 from each player\",\"ReceiveFromOtherPlayers\",-10,NULL,\"playerId\")");
				dbCmd.CommandText = sqlQueryPotLuck; //Gives the query to the commandtext
				dbCmd.ExecuteScalar (); //Executes the query
			}
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				//Creates a query for inserting the new score
				string sqlQueryOpKn = String.Format ("INSERT INTO OpportunityKnocks (\n\t\tcardNo, description, category, cost, moves, moveToLocation, receiver, houseCost, hotelCost)\n\tVALUES\n\t\t(0,\"You are assessed for repairs, £40/house, £115/hotel\",\"Repairs\",0,0,NULL,\"BANK\",40,115),\n\t\t(1,\"Advance to Turing Heights\",\"GoBackwards\",0,0,40,NULL,NULL,NULL),\n\t\t(2,\"Advance to Han Xin Gardens. If you pass GO, collect £200\",\"GoForward\",0,0,25,NULL,NULL,NULL),\n\t\t(3,\"Take a trip to Hove station. If you pass GO collect £200\",\"GoForward\",0,0,16,NULL,NULL,NULL),\n\t\t(4,\"Advance to GO\",\"GoForward\",0,0,1,NULL,NULL,NULL),\n\t\t(5,\"Advance to Skywalker Drive. If you pass GO collect £200\",\"GoForward\",0,0,12,NULL,NULL,NULL),\n\t\t(6,\"Get out of jail free\",\"GetOutOfJailFree\",0,0,NULL,NULL,NULL,NULL),\n\t\t(7,\"Go to jail. Do not pass GO, do not collect £200\",\"Jail\",0,0,31,NULL,NULL,NULL),\n\t\t(8,\"Pay university fees of £150\",\"Pay bank\",150,0,NULL,\"BANK\",NULL,NULL),\n\t\t(9,\"You are assessed for repairs, £25/house, £100/hotel\",\"CalcPayToBank\",0,0,NULL,\"BANK\",25,100),\n\t\t(10,\"Fined £15 for speeding\",\"PayFreeParking\",15,0,NULL,\"FreeParking\",NULL,NULL),\n\t\t(11,\"Drunk in charge of a skateboard. Fine £20\",\"PayFreeParking\",20,0,NULL,\"FreeParking\",NULL,NULL),\n\t\t(12,\"Bank pays you divided of £50\",\"ReceiveFromBank\",-50,0,NULL,\"playerId\",NULL,NULL),\n\t\t(13,\"You have won a lip sync battle. Collect £100\",\"ReceiveFromBank\",-100,0,NULL,\"playerId\",NULL,NULL),\n\t\t(14,\"Loan matures, collect £150\",\"ReceiveFromBank\",-150,0,NULL,\"playerId\",NULL,NULL),\n\t\t(15,\"Go back 3 spaces\",\"GoBackwards\",0,3,NULL,NULL,NULL,NULL)");
				dbCmd.CommandText = sqlQueryOpKn;
				dbCmd.ExecuteScalar (); //Executes the query

				dbConnection.Close ();//Closes the connection
			}
		}
	}

	/*private ArrayList getCards(){
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery = query;
				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Debug.Log(reader.GetString(0));
					}
					dbConnection.Close();
					reader.Close();
				}
			}
		}
	}*/
}

