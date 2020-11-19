using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StraviaTEC_Backend.Models;
using System.Data;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTEC_Backend.DataBaseAccess
{
    public class DataBaseHandler : Controller
    {
        
        /**************** READ TABLE ***************************/
        /** <summary> GET DATA FROM DATABASE </summary>**/
        /**<param name="tableRequest"> TABLE TO FETCH DATA </param>**/
        /**<param name="attributes"> ATTRIBUTES TO BE DISPLAYED </param>**/
        /**<returns> ROWS ATTRIBUTES </returns>**/
        public NpgsqlDataReader readFromDataBase(string tableRequest, string attributes)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
            connection.Open();
            string query = "SELECT " + attributes + " FROM " + tableRequest;
            NpgsqlCommand connector = new NpgsqlCommand(query, connection);
            //NpgsqlDataReader reader = connector.ExecuteReader();
            return connector.ExecuteReader();//reader;
        }

        public NpgsqlDataReader getSingleRecord(string tableRequest,string conditionAttrib, string keyAttrib)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
            connection.Open();
            string query = "SELECT * FROM " + tableRequest + " WHERE " +  conditionAttrib + " = " + "'" + keyAttrib + "'";
            NpgsqlCommand connector = new NpgsqlCommand(query, connection);
            //NpgsqlDataReader reader = connector.ExecuteReader();
            return connector.ExecuteReader();
            
        }

        /**************** INSERT ***************************/
        /**<summary> INSERT NEW DATA INTO DATABASE </summary>**/
        /**<param name="tableRequest"> TABLE TO INSERT DATA </param>**/
        /**<param name="attributes"> ATTRIBUTES TO BE ADDED </param>**/
        /**<param name="dataInsertion"> DATA TO INSERT </param>**/
        public bool insertDataBase(string tableRequest, string attributes, string dataInsertion)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                using var commandRequest = new NpgsqlCommand();
                commandRequest.Connection = connection;
                commandRequest.CommandText = "INSERT INTO " + tableRequest + "(" + attributes + ") VALUES('" + dataInsertion + ")";
                commandRequest.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**************** UPDATE ***************************/
        /**<summary> UPDATE ROWS IN DATABASE TABLES </summary>**/
        /**<param name="tableRequest"> TABLE TO UPDATE DATA </param>**/
        /**<param name="attribToModify"> ATRIBUTE TO MODIFY IN A TABLE </param>**/
        /**<param name="dataInsertion"> NEW VALUE TO A ATRIBUTE IN ROW </param>**/
        /**<param name="conditionAttrib"> ATTRIBUTE AND CONDITION VALUE TO UPDATE TABLE </param>**/
        public bool updateDataBase(string tableRequest, string attribToModifyInsertion, string conditionAttrib)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                using var commandRequest = new NpgsqlCommand();
                commandRequest.Connection = connection;
                commandRequest.CommandText = "UPDATE " + tableRequest + " SET " + attribToModifyInsertion + " WHERE " + conditionAttrib;
                commandRequest.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**************** DELETE ***************************/
        /**<summary> DELETE ROWS IN DATABASE TABLE </summary>**/
        /**<param name="tableRequest"> TABLE TO SEARCH DELETE CONDITION </param>**/
        /**<param name="conditionAttrib"> SET A CONDITION TO DELETE A ROW IN DATABASE </param>**/
        public bool deleteFromDataBase(string tableRequest, string conditionAttrib)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                using var commandRequest = new NpgsqlCommand();
                commandRequest.Connection = connection;
                commandRequest.CommandText = "DELETE FROM " + tableRequest + " WHERE " + conditionAttrib;
                commandRequest.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}