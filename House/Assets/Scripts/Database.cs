using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class Database : MonoBehaviour {
	private string connectionString;
	private int gameNo;

	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/PropertyTycoon.db";
		GetBoardData ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetBoardData() {
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();

			using (IDbCommand dbCmd = dbConnection.CreateCommand()) {
				string sqlQuery = "SELECT * from DevProperties\nUNION \nSELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, rent1_St AS rent_1, rent2_St AS rent_2,rent3_St AS rent_3, rent4_St AS rent_4, NULL AS rent_5\nfrom Stations\nUNION \nSELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, rent1_Ut AS rent_1, rent2_Ut AS rent_2,NULL AS rent_3, NULL AS rent_4, NULL AS rent_5\nfrom Utilities\nunion\nSELECT tileNo, prop_name, group_, cost, NULL as undeveloped_rent, NULL AS undeveloped_rentAll, NULL AS rent_1, NULL AS rent_2,NULL AS rent_3, NULL AS rent_4, NULL AS rent_5\nfrom NonProperties\nORDER BY tileNo";

				dbCmd.CommandText = sqlQuery;
				using(IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{

						Tile t = new Tile (reader.GetString(1), reader.GetString(2), reader.GetInt16(3));

						t._tileEventHandler += new TileAddDelegate(TileListener.ShowTiles);

						Game.board [reader.GetInt16 (0) - 1] = t;

						//t.LocatePlayer(5);

						//Tile tile = Game.board [reader.GetInt16 (0) - 1];
						//Debug.Log (tile.GetName() + ", " + tile.GetPrice() + ", " + tile.GetGroup());
					}
					dbConnection.Close();
					reader.Close();

				}
			}
		}
	}
}
