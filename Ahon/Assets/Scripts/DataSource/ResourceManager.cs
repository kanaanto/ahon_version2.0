﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.IO;
using Assets.Scripts.DataSource;
using Assets.Scripts.Classes;
/*
 * c/o Kana
 * kanaantonio@gmail.com
 */
namespace Assets.Scripts.DataSource
{
    public class ResourceManager
    {
        public IDbConnection dbConn;
        public Connection dsc;

        public ResourceManager(IDbConnection dbConn){
            this.dbConn = dbConn;
        }

        public List<Resource> GetResources(int level)
        {
            Debug.Log("Getting Resources");
            IDbCommand dbCmd;
            IDataReader reader;

            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = "SELECT c.name AS 'ResourceName', c.img AS " +
                "'ResourceImage', c.survivalTime AS 'SurvivalTime', " +
                " c.maxNoOfOccupants AS 'MaxNoOfOccupants', " +
                " c.prefabtoInstantiate AS 'PrefabtoInstantiate', c.price AS 'Price', " +
                " b.quantity AS 'Quantity'," +
                "d.position_x, d.position_y, d.position_z " +
                "FROM level a JOIN lev_res b ON a.id = b.lev_id " +
                "JOIN resource c ON b.res_id = c.id " +
                "JOIN _points d ON b.res_id = d.ref_asset " +
                "WHERE (ResourceName <> 'Tree' AND ResourceName <> 'Coconut') AND a.id= " + level;

            reader = dbCmd.ExecuteReader();
            string name = "";
            string image = "";
            int survivalTime = 0;
            int maxNoOfOccupants = 0;
            string prefabToInstantiate = "";
            int price = 0;
            int quantity = 0;
            float position_x = 0;
            float position_y = 0;
            float position_z = 0;

            List<Resource> resources = new List<Resource>();
            while (reader.Read())
            {
                name = reader.GetString(0);
                image = reader.GetString(1);
                survivalTime = reader.GetInt16(2);
                maxNoOfOccupants = reader.GetInt16(3);
                prefabToInstantiate = reader.GetString(4);
                price = reader.GetInt16(5);
                quantity = reader.GetInt16(6);
                position_x = reader.GetFloat(7);
                position_y = reader.GetFloat(8);
                position_z = reader.GetFloat(9);
                /*
                Resource resource = new Resource(name, image, survivalTime,
                    quantity, position_x, position_y, position_z);
                resources.Add(resource);
                */
                Resource resource = new Resource(name, image, survivalTime, maxNoOfOccupants, prefabToInstantiate, price,
                                                 quantity, position_x, position_y, position_z);
                resources.Add(resource);
            }
            dbConn.Close();

            return resources;
        }
        public List<Resource> GetResourceNames(int level)
        {
            Debug.Log("Getting Resource Names");
            IDbCommand dbCmd;
            IDataReader reader;

            dbConn = dsc.GetInstance();
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();
            dbCmd.CommandText = "SELECT c.name AS 'ResourceName', c.img AS 'ResourceImage', " +
                " c.prefabtoInstantiate AS 'PrefabtoInstantiate', c.price AS 'Price' " +
                "FROM level a LEFT JOIN lev_res b ON a.id = b.lev_id " +
                "LEFT JOIN resource c ON b.res_id = c.id " +
                "WHERE (ResourceName <> 'Tree' AND ResourceName <> 'Coconut')  AND a.id= " + level;
            reader = dbCmd.ExecuteReader();
            string name = "";
            string image = "";
            int price = 0;
            string prefabToInstantiate = "";

            List<Resource> resources = new List<Resource>();
            while (reader.Read())
            {
                name = reader.GetString(0);
                image = reader.GetString(1);
                prefabToInstantiate = reader.GetString(2);
                price = reader.GetInt16(3);



                Resource resource = new Resource(name, image, 0, 0, prefabToInstantiate, price,
                                                 0, 0, 0, 0);
                resources.Add(resource);
            }
            dbConn.Close();

            return resources;
        }
        // get pabahay, blue house and nipa huts
        public List<Resource> GetPabahayPoints(int level)
        {
            Debug.Log("Getting Resource Points (Pabahay, Nipa Hut, Blue House )");
            IDbCommand dbCmd;
            IDataReader reader;

            dbConn = dsc.GetInstance();
            dbConn.Open();
            dbCmd = dbConn.CreateCommand();

            dbCmd.CommandText = "SELECT ref_asset, position_x, position_y, position_z, " +
                "name, img, survivalTime, maxnoofoccupants FROM _points p left join " +
                "resource r on p.ref_asset = r.id where ref_asset in (3, 8, 9, 10) and level = " + level;
            reader = dbCmd.ExecuteReader();

            float position_x = 0f;
            float position_y = 0f;
            float position_z = 0f;
            string name = "";
            string image = "";
            int survivalTime = 0;
            int occupants = 0;

            List<Resource> resources = new List<Resource>();
            while (reader.Read())
            {
                position_x = reader.GetFloat(1);
                position_y = reader.GetFloat(2);
                position_z = reader.GetFloat(3);

                name = reader.GetString(4);
                image = reader.GetString(5);
                survivalTime = reader.GetInt16(6);
                occupants = reader.GetInt16(7);

                Resource resource = new Resource(name, image, survivalTime, occupants, image, 0,
                                                 1, position_x, position_y, position_z);
                resources.Add(resource);
            }
            dbConn.Close();

            return resources;
        }
    }
}
