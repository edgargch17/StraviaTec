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
        /** <summary>GET DATA FROM DATABASE </summary>**/
        /**<param name="tableRequest"> TABLE TO FETCH DATA </param>**/
        /**<param name="attributes"> ATTRIBUTES TO BE DISPLAYED </param>**/
        /**<returns> ROWS ATTRIBUTES </returns>**/
        public List<Athlete> readFromDataBase(string tableRequest, string attributes)
        {
            List <Athlete> athletes = new List<Athlete>();
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
            connection.Open();
            string query = "SELECT " + attributes + " FROM " + tableRequest;
            NpgsqlCommand connector = new NpgsqlCommand(query, connection);
            NpgsqlDataReader reader = connector.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    athletes.Add(
                       new Athlete()
                       {
                           username = (string)reader["username"],
                           password = (string)reader["password"],
                           name = (string)reader["name"],
                           last_name = (string)reader["last_name"],
                           nationality = (string)reader["nationality"],
                           birth_date = (DateTime)reader["birth_date"],
                           photo = (string)reader["photo"],
                           age = (int)reader["age"]
                       });
                }
            }
            catch (Exception e)
            {

            }
            connection.Close();
            return athletes;
        }

        /**************** INSERT ***************************/
        /**<summary> INSERT NEW DATA INTO DATABASE </summary>**/
        /**<param name="tableRequest"> TABLE TO INSERT DATA </param>**/
        /**<param name="attributes"> ATTRIBUTES TO BE ADDED </param>**/
        /**<param name="dataInsertion"> DATA TO INSERT </param>**/
        public void insertDataBase(string tableRequest, string attributes, string dataInsertion)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
                connection.Open();
                using var commaandRequest = new NpgsqlCommand();
                commaandRequest.Connection = connection;
                commaandRequest.CommandText = "INSERT INTO " + tableRequest + "(" + attributes + ") VALUES('" + dataInsertion + "')";
                commaandRequest.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
            }
        }

        /**************** UPDATE ***************************/
        /**<summary> UPDATE ROWS IN DATABASE TABLES </summary>**/
        /**<param name="tableRequest"> TABLE TO UPDATE DATA </param>**/
        /**<param name="attribToModify"> ATRIBUTE TO MODIFY IN A TABLE </param>**/
        /**<param name="dataInsertion"> NEW VALUE TO A ATRIBUTE IN ROW </param>**/
        /**<param name="conditionAttrib"> ATTRIBUTE AND CONDITION VALUE TO UPDATE TABLE </param>**/
        public void updateDataBase(string tableRequest, string attribToModify, string dataInsertion, string conditionAttrib)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
            connection.Open();
            using var commandRequest = new NpgsqlCommand();
            commandRequest.Connection = connection;
            commandRequest.CommandText = "UPDATE " + tableRequest + " SET " + attribToModify +" = " + dataInsertion + " WHERE " + conditionAttrib;
            commandRequest.ExecuteNonQuery();
            connection.Close();
        }

        /**************** DELETE ***************************/
        /**<summary> DELETE ROWS IN DATABASE TABLE </summary>**/
        /**<param name="tableRequest"> TABLE TO SEARCH DELETE CONDITION </param>**/
        /**<param name="conditionAttrib"> SET A CONDITION TO DELETE A ROW IN DATABASE </param>**/
        public void deleteFromDataBase(string tableRequest, string conditionAttrib)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DataBaseConstants.dataBaseConnection);
            connection.Open();
            using var commandRequest = new NpgsqlCommand();
            commandRequest.Connection = connection;
            commandRequest.CommandText = "DELETE FROM " + tableRequest + " WHERE " + conditionAttrib;
            commandRequest.ExecuteNonQuery();
            connection.Close();
        }
    }
}