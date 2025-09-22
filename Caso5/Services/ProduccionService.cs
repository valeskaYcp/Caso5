using Caso5.Models;
using Caso5_Gestion_de_producci_n.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caso5.Services
{
    public class ProduccionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProduccionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Obtener todas las órdenes
        public async Task<IEnumerable<OrdenesProduccion>> ObtenerOrdenesAsync()
        {
            return await _unitOfWork.Repository<OrdenesProduccion>().GetAllAsync();
        }

        // Obtener etapas de una orden
        public async Task<IEnumerable<EtapasProduccion>> ObtenerEtapasPorOrdenAsync(int ordenId)
        {
            return await _unitOfWork.Repository<EtapasProduccion>().FindAsync(e => e.OrdenId == ordenId);
        }

        // Registrar una nueva etapa
        public async Task RegistrarEtapaAsync(EtapasProduccion etapa)
        {
            await _unitOfWork.Repository<EtapasProduccion>().AddAndSaveAsync(etapa);
        }

        // Actualizar estado de una orden
        public async Task ActualizarEstadoOrdenAsync(int ordenId, string estado)
        {
            var orden = await _unitOfWork.Repository<OrdenesProduccion>().GetByIdAsync(ordenId);
            if (orden == null) throw new Exception("Orden no encontrada");

            orden.Estado = estado;
            _unitOfWork.Repository<OrdenesProduccion>().Update(orden);
            await _unitOfWork.SaveAsync();
        }
        
        //porcentaje de productos defectuosos en una etapa
        public async Task<decimal> ObtenerPorcentajeDefectuososAsync(int etapaId)
        {
            var inspecciones = await _unitOfWork.Repository<InspeccionesCalidad>()
                .FindAsync(i => i.EtapaId == etapaId);
            var total = inspecciones.Sum(i => (decimal)i.ProductosDefectuosos);
            var procesados = inspecciones.Sum(i => (decimal?)i.Etapa?.CantidadProcesada ?? 0);

            return procesados > 0 ? total / procesados * 100 : 0;
        }


    }
}