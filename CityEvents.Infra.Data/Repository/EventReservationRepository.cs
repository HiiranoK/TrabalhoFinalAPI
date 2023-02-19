using CityEvents.Service.DTO;
using CityEvents.Service.Entity;
using CityEvents.Service.Interface;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly string _stringConnection;
        public EventReservationRepository() {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }
        public async Task<IEnumerable<EventReservationEntity>> ConsultaReserva(string nome, string tituloEvento)
        {
            string query = "SELECT * FROM EventReservation  INNER JOIN CityEvent ON CityEvent.IdEvent = EventReservation.IdEvent WHERE PersonName = @nome  AND Title LIKE @titulo";
            DynamicParameters parametro = new();
            tituloEvento = $"%{tituloEvento}%";
            parametro.Add("nome", nome);
            parametro.Add("titulo",tituloEvento);
            using MySqlConnection conn = new(_stringConnection);
            return  conn.Query<EventReservationEntity>(query, parametro).ToList();
        }

        public async Task<bool> DeletaReserva(int id)
        {
            string query = "DELETE FROM EventReservation where id = @id";
            DynamicParameters parametro = new(id);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametro);
            return linhasAfetadas > 0;
        }

        public async Task<bool> EditarQuantidadeReserva(int id, int quantidade)
        {
            string query = "UPDATE EventReservation SET Quantity = @quantidade where idReservation = @id";
            DynamicParameters parametro = new(id);
            parametro.Add("quantidade",quantidade);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametro);
            return linhasAfetadas > 0;
        }

        public async Task<bool> AdicionarReserva(EventReservationEntity reserva)
        {
            string query = "INSERT INTO EventReservation (IdEvent,PersonName,Quantity) VALUES (@IdEvent,@PersonName,@Quantity)";
            DynamicParameters parametro = new(reserva);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametro);
            return linhasAfetadas > 0;
        }

        public async Task<bool> ValidaStatusEvento(int idEvento)
        {
            string query = "SELECT * FROM CityEvent where idEvent = @idEvento";
            DynamicParameters parametro = new();
            parametro.Add("idEvento", idEvento);
            using MySqlConnection conn = new(_stringConnection);
            var valor = await conn.QueryFirstOrDefaultAsync<CityEventDto>(query, parametro);
            return valor.Status;
        }
    }
}
