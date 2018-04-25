using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;


public class databaseConnection : MonoBehaviour {

	private string connectionString;
	private int gameNo;
	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/PropertyTycoon.db";
		//GetData ();
		//createBoard();
		//newGame();
		createPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void GetData(){
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery = "select * from Players";
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
	}

	private void createPlayers(){
		
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
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
				}
			}
			//Creates a database command
			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				//Creates a query for inserting the data

				string sqlQuery = String.Format("INSERT INTO Players(player_id, gameNo, token_loc, token_shape, wallet, get_out_of_jail_card, bot, jail, player_name) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")","BANK", gameNo, 0, "BANK", 10000, 2, 0, 0, "KINGSLEY SAGE");
				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
				dbCmd.ExecuteScalar(); //Executes the query
				dbConnection.Close();//Closes the connection


			}
		}

	}

	private void createBoard(){
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			//Opens the connection
			dbConnection.Open ();

			//Creates a database comment
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {
				//Creates a query for inserting the new score
				string sqlQuery = String.Format ("\t/*GAMETABLE*/\n\nCREATE TABLE GameTable (\n    gameNo    INTEGER PRIMARY KEY AUTOINCREMENT,\n    time_     TIME,\n    date_     DATE,\n    trading   BOOLEAN CHECK (trading IN (0, 1) ) NOT NULL\n);\n\n\t/*DEV PROPERTIES*/\n\nCREATE TABLE DevProperties (\n    tileNo INTEGER NOT NULL,\n    prop_name VARCHAR (50),\n    group_ VARCHAR (15),\n    cost INTEGER NOT NULL,\n    undeveloped_rent INTEGER NOT NULL,\n    undeveloped_rentAll INTEGER NOT NULL,\n    rent_1 INTEGER NOT NULL,\n    rent_2 INTEGER NOT NULL,\n    rent_3 INTEGER NOT NULL,\n    rent_4 INTEGER NOT NULL,\n    rent_5 INTEGER NOT NULL,\n    PRIMARY KEY \n        (tileNo)\n    );\n\n\t/*STATIONS*/\n\nCREATE TABLE Stations (\n    tileNo   INTEGER,\n    prop_name VARCHAR(50),\n    group_ VARCHAR (15) NOT NULL DEFAULT \"Stations\",\n    cost INTEGER NOT NULL DEFAULT 200,\n    rent1_St INTEGER NOT NULL DEFAULT 25,\n    rent2_St INTEGER NOT NULL DEFAULT 50,\n    rent3_St INTEGER NOT NULL DEFAULT 100,\n    rent4_St INTEGER NOT NULL DEFAULT 200,\n    PRIMARY KEY \n        (tileNo)\n    );\n\n\t/*UTILITIES*/\n\n\nCREATE TABLE Utilities (\n    tileNo INTEGER,\n    prop_name VARCHAR(50),\n    group_ VARCHAR(50) NOT NULL DEFAULT \"Utilities\",\n    cost INTEGER,\n    rent1_Ut INTEGER DEFAULT 4,\n    rent2_Ut INTEGER DEFAULT 10,\n    PRIMARY KEY \n        (tileNo)  \n);\n\nCREATE TABLE NonProperties (\n    tileNo INTEGER,\n    prop_name VARCHAR(50),\n    group_ VARCHAR(50),\n    cost INTEGER,\n    PRIMARY KEY \n        (tileNo)\n    );\n\n\t/*PLAYER*/\n\n/* Free parking as player????*/\n\nCREATE TABLE Players (\n    player_id VARCHAR(50),\n    gameNo INTEGER,\n    token_loc INTEGER,\n    token_shape VARCHAR(50),\n    wallet INTEGER(50),  /* set intial amount of money in settings */\n    get_out_of_jail_card INTEGER(50),\n    player_name VARCHAR(50),\n    PRIMARY KEY (\n        player_id\n    ),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo)\n);\n\n\t\t/*ACCOUNT*/\n\n\nCREATE TABLE Account (\n    player_id VARCHAR(50),\n    password_ VARCHAR (50),\n    PRIMARY KEY (\n        player_id\n    )\n);\n\n\n    /*DEV ASSETS*/\n\nCREATE TABLE devAssets (\n    assetNo   INTEGER,\n    developed INTEGER,\n    player_id INTEGER,\n    gameNo INTEGER,\n    mortgaged BOOLEAN,\n    FOREIGN KEY (\n        assetNo\n    )\n    REFERENCES DevProperties (tileNo),\n    FOREIGN KEY (\n        player_id\n    )\n    REFERENCES Players (player_id),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo) \n);\n\n    /*NON DEV ASSETS*/\n\nCREATE TABLE UtilitiesAssets (\n    assetNo INTEGER,\n    type VARCHAR(50),\n    player_id INTEGER,\n    gameNo INTEGER,\n    mortgaged BOOLEAN,\n    FOREIGN KEY (\n        assetNo\n    )\n    REFERENCES Utilities (tileNo),\n    FOREIGN KEY (\n        player_id\n    )\n    REFERENCES Players (player_id),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo)   \n);\n\nCREATE TABLE StationAssets (\n    assetNo INTEGER,\n    type VARCHAR(50),\n    player_id INTEGER,\n    gameNo INTEGER,\n    mortgaged BOOLEAN,\n    FOREIGN KEY (\n        assetNo\n    )\n    REFERENCES Stations (tileNo),\n    FOREIGN KEY (\n        player_id\n    )\n    REFERENCES Players (player_id),\n    FOREIGN KEY (\n        gameNo\n    )\n    REFERENCES GameTable (gameNo)\n    )");

				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext

				dbCmd.ExecuteScalar (); //Executes the query
				dbConnection.Close ();//Closes the connetion
			}
		}
	}

	private void newGame(){
		int trading = 1;
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			//Opens the connection
			dbConnection.Open ();

			//Creates a database comment
			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				//Creates a query for inserting the new score
				string sqlQuery = String.Format ("INSERT INTO GameTable(trading)VALUES("+ trading + ")");
				dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
				dbCmd.ExecuteScalar (); //Executes the query
				dbConnection.Close ();//Closes the connetion
			}
		}
	}

}


