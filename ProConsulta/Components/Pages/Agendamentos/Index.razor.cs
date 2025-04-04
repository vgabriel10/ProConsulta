﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class IndexAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar SnackBar { get; set; } = null!;

        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        public bool HideButtons { get; set; } = false;

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task DeleteAgendamento(Agendamento agendamento)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                    (
                    "Atenção",
                    "Deseja excluir este agendamento",
                    yesText: "Sim",
                    cancelText: "Não"
                    );

                if(result is true)
                {
                    await AgendamentoRepository.DeleteByIdAsync(agendamento.Id);
                    SnackBar.Add("Agendamento excluido com sucesso!", Severity.Success);
                    await OnInitializedAsync();                }
            }
            catch(Exception ex)
            {
                SnackBar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;
            HideButtons = !auth.User.IsInRole("Atendente");
            Agendamentos = await AgendamentoRepository.GetAllAsync();
        }
    }
}
