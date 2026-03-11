using AutoMapper;
using Domain.Dtos.Orcamentos.PorHora;
using Domain.Dtos.Orcamentos.PorProjeto;
using Domain.Entidades;
using Domain.Repositories;
using Domain.Services.Report;
using FastReport.Export.PdfSimple;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Services.reports
{
    public class ReportService : IReportService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IOrcamentoHoraRepository _orcamentoHoraRepository;
        private readonly IOrcamentoPorProjetoRepository _orcamentoPorProjetoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public ReportService(IProjetoRepository projetoRepository, IMapper mapper, IEmpresaRepository empresaRepository, ITarefaRepository tarefaRepository, IClienteRepository clienteRepository, IOrcamentoHoraRepository orcamentoHoraRepository, IOrcamentoPorProjetoRepository orcamentoPorProjetoRepository)
        {
            _projetoRepository = projetoRepository;
            _tarefaRepository = tarefaRepository;
            _orcamentoHoraRepository = orcamentoHoraRepository;
            _orcamentoPorProjetoRepository = orcamentoPorProjetoRepository;
            _clienteRepository = clienteRepository;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        private TimeSpan CalcularHorasDoProjeto(IEnumerable<TarefaEntity> tarefas)
        {
            TimeSpan totalHora = TimeSpan.Zero;
            foreach (var tarefa in tarefas)
            {
                totalHora += tarefa.Duracao.TimeOfDay;
            }
            var hour = (int)totalHora.TotalHours;
            var minute = totalHora.Minutes;
            return totalHora;
        }

        private double CalcularValorDoProjeto(double totalHoras)
        {
            if (totalHoras > 0)
            {
                double total = 0;
                total = totalHoras * 50;
                return total;
            }
            return 0;

        }

        public async Task<byte[]> OrcamentoPorProjeto(Guid orcamentoId)
        {
            try
            {
                var orcamento = await _orcamentoPorProjetoRepository.GetByIdWithRelationships(orcamentoId);
                var cliente = await _clienteRepository.SelectAsync(orcamento.ClienteId);
                var empresa = await _empresaRepository.SelectAsync(orcamento.EmpresaId);
                var orcamentoDto = _mapper.Map<OrcamentoPorProjetoDtoReport>(orcamento);
                orcamentoDto.CreateAt = orcamento.CreateAt.Value.ToString("dd/MM/yyyy");


                List<OrcamentoPorProjetoDtoReport> orcamentos = [orcamentoDto];
                List<ClienteEntity> clientes = [cliente];
                List<EmpresaEntity> empresas = [empresa];

                var reportPath = Path.Combine("Services", "reports", "OrcamentoPorProjeto.frx");
                var webReport = HelperFastReport.WebReport(reportPath);


                var orcamentoTable = HelperFastReport.GetTable(orcamentos, "OrcamentoPorProjeto");
                var clienteTable = HelperFastReport.GetTable(clientes, "Clientes");
                var empresaTable = HelperFastReport.GetTable(empresas, "Empresa");
                var produtosOrcamentoTable = HelperFastReport.GetTable(orcamento.Produtos, "ProdutosOrcamentoPorProjeto");

                webReport.Report.RegisterData(orcamentoTable, "OrcamentoPorProjeto");
                webReport.Report.RegisterData(clienteTable, "Clientes");
                webReport.Report.RegisterData(empresaTable, "Empresa");
                webReport.Report.RegisterData(produtosOrcamentoTable, "ProdutoOrcamentoProjeto");
                return HelperFastReport.ExportPdf(webReport);



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<byte[]> OrcamentoHora(Guid orcamentoId)
        {
            try
            {
                var orcamento = await _orcamentoHoraRepository.GetByIdWithRelationships(orcamentoId);
                var empresa = await _empresaRepository.GetWithRealationship(orcamento.EmpresaId);
                var cliente = await _clienteRepository.SelectAsync(orcamento.ClienteId);
                var orcamentoDto = _mapper.Map<OrcamentoHoraDtoReport>(orcamento);
                orcamentoDto.CreateAt = orcamento.CreateAt.Value.ToString("dd/MM/yyyy");
                var reportPath = Path.Combine("Services", "reports", "orcamentoHora.frx");
                var webReport = HelperFastReport.WebReport(reportPath);

                List<OrcamentoHoraDtoReport> orcamentos = [orcamentoDto];
                List<ClienteEntity> clientes = [cliente];
                List<EmpresaEntity> empresas = [empresa];

                var orcamentoTable = HelperFastReport.GetTable(orcamentos, "OrcamentoHora");
                var clienteTable = HelperFastReport.GetTable(clientes, "Clientes");
                var empresaTable = HelperFastReport.GetTable(empresas, "Empresa");
                var servicosTable = HelperFastReport.GetTable(orcamento.Servicos, "Servico");

                webReport.Report.RegisterData(orcamentoTable, "OrcamentoHora");
                webReport.Report.RegisterData(clienteTable, "Clientes");
                webReport.Report.RegisterData(empresaTable, "Empresa");
                webReport.Report.RegisterData(servicosTable, "Servico");
                return HelperFastReport.ExportPdf(webReport);

            }
            catch
            {
                throw;
            }
        }


        public async Task<byte[]> ServicosPrestados(Guid projetoId)
        {
            try
            {
                var projeto = await _projetoRepository.SelectProjectWithRealationShipsAsync(projetoId);
                var tarefas = (await _tarefaRepository.GetAllByProjectAsync(projetoId)).OrderBy(t => t.Data);

                var timeTotal = CalcularHorasDoProjeto(tarefas);
                var hour = (int)timeTotal.TotalHours;
                var minute = timeTotal.Minutes;
                projeto.TotalHoras = $"{hour:D2}:{minute:D2}";
                projeto.ValorTotalProjeto = CalcularValorDoProjeto(timeTotal.TotalHours);

                var reportPath = Path.Combine("Services", "reports", "relatorio-servicos-prestados.frx");
                var webReport = HelperFastReport.WebReport(reportPath);

                List<ProjetoEntity> projetoList = [projeto];
                var projetoTable = HelperFastReport.GetTable<ProjetoEntity>(projetoList, "Projetos");

                List<ClienteEntity> ClienteList = [projeto.Cliente];
                var clienteTable = HelperFastReport.GetTable<ClienteEntity>(ClienteList, "Clientes");

                var tarefasTable = HelperFastReport.GetTable<TarefaEntity>(tarefas, "Tarefas");


                webReport.Report.RegisterData(projetoTable, "Projetos");
                webReport.Report.RegisterData(clienteTable, "Clientes");
                webReport.Report.RegisterData(tarefasTable, "Tarefas");
                return HelperFastReport.ExportPdf(webReport);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<byte[]> ServicosPrestadosPorPeriodo(Guid projetoId, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var projeto = await _projetoRepository.SelectProjectWithRealationShipsAsync(projetoId);
                projeto.DataInicio = dataInicio;
                projeto.DataFim = dataFim;
                var tarefas = (await _tarefaRepository.GetAllByProjectWithRangeAsync(projetoId, dataInicio, dataFim)).OrderBy(t => t.Data);

                var timeTotal = CalcularHorasDoProjeto(tarefas);
                var hour = (int)timeTotal.TotalHours;
                var minute = timeTotal.Minutes;
                projeto.TotalHoras = $"{hour:D2}:{minute:D2}";
                projeto.ValorTotalProjeto = CalcularValorDoProjeto(timeTotal.TotalHours);

                var reportPath = Path.Combine("Services", "reports", "relatorio-servicos-prestados-periodo.frx");
                var webReport = HelperFastReport.WebReport(reportPath);

                List<ProjetoEntity> projetoList = [projeto];
                var projetoTable = HelperFastReport.GetTable<ProjetoEntity>(projetoList, "Projetos");

                List<ClienteEntity> ClienteList = [projeto.Cliente];
                var clienteTable = HelperFastReport.GetTable<ClienteEntity>(ClienteList, "Clientes");

                var tarefasTable = HelperFastReport.GetTable<TarefaEntity>(tarefas, "Tarefas");


                webReport.Report.RegisterData(projetoTable, "Projetos");
                webReport.Report.RegisterData(clienteTable, "Clientes");
                webReport.Report.RegisterData(tarefasTable, "Tarefas");
                return HelperFastReport.ExportPdf(webReport);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
