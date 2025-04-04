﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class CreateAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;

        [Inject]
        private IMedicoRepository MedicoRepository { get; set; } = null!;

        [Inject]
        private IPacienteRepository PacienteRepository { get; set; } = null!;

        [Inject]
        public ISnackbar SnackBar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();

        public List<Medico> Medicos { get; set; } = new List<Medico>();
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public TimeSpan? Time { get; set; } = new TimeSpan(09, 00, 00);
        public DateTime? Date { get; set; } = DateTime.Now.Date;
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AgendamentoInputModel model)
                {
                    var agendamento = new Agendamento
                    {
                        Observacao = model.Observacao,
                        PacienteId = model.PacienteId,
                        MedicoId = model.MedicoId,
                        HoraConsulta = Time!.Value,
                        DataConsulta = Date!.Value
                    };

                    await AgendamentoRepository.AddAsync(agendamento);
                    SnackBar.Add("Agendamento realizado com sucesso!");
                    NavigationManager.NavigateTo("/agendamentos");
                }
            }
            catch(Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
                
        }

        protected override async Task OnInitializedAsync()
        {
            Medicos = await MedicoRepository.GetAllAsync();
            Pacientes = await PacienteRepository.GetAllAsync();

        }
    }
}
