

$(document).ready(function () {

    
    var idUsuarios; // Declarar idUsuario fuera de la función de clic del botón

    cargarAlertas();
    var idEquipoTemp; // Variable para almacenar temporalmente el valor de IdUsuario

    // Captura el evento click del botón de Visualizar
    $('#datatablesSimple').on('click', '.btn-info', function () {
        var idEquipo = $(this).data('id'); // Obtén el ID de equipo de la fila seleccionada

        idEmpleadoTemp = idEquipo; // Almacena el valor de IdUsuario temporalmente

        // Hacer una solicitud AJAX para obtener los datos del usuario
        $.ajax({
            url: '/EquipoBaja/ObtenerEquipo', // URL de tu controlador que obtiene los datos del usuario
            type: 'GET',
            data: { idEquipo: idEquipo }, // Envía el ID de usuario como parámetro
            success: function (response) {
                var fechaDesdeSQL = response.fecha_adquision;
                var partesFecha = fechaDesdeSQL.split('-');
                var fechaFormateada = partesFecha[0] + '-' + partesFecha[1] + '-' + partesFecha[2];

                var fechaDesdeSQL2 = response.inicio_garantia;
                var partesFecha2 = fechaDesdeSQL2.split('-');
                var fechaFormateada2 = partesFecha2[0] + '-' + partesFecha2[1] + '-' + partesFecha2[2];

                var fechaDesdeSQL3 = response.fin_garantia;
                var partesFecha3 = fechaDesdeSQL3.split('-');
                var fechaFormateada3 = partesFecha3[0] + '-' + partesFecha3[1] + '-' + partesFecha3[2];


                // Asignar la fecha formateada al input de tipo date
                $('#FechaAdquisionV').val(fechaFormateada);
                $('#InicioGarantiaV').val(fechaFormateada2);
                $('#FinGarantiaV').val(fechaFormateada3);

                $('#EmpleadoV').val(response.empleado);
                $('#ResponsivaV').val(response.responsiva + 'C');
                $('#NombreV').val(response.nombre);
                $('#ServiceTagV').val(response.service_tag);
                $('#ModeloV').val(response.modelo);
                $('#TipoEquipoV').val(response.tipo_equipo);
                $('#DominioV').val(response.dominio);
                $('#EstadoV').val(response.estado);
                $('#ResguardoV').val(response.resguardo);
                $('#ActivoFijoV').val(response.activo_fijo);
                $('#AdquisionV').val(response.adquision);
                $('#MarcaV').val(response.marca);
                $('#SistemaOperativoV').val(response.sistema_operativo);
                $('#ProcesadorV').val(response.procesador);
                $('#OfficeVersionV').val(response.office_version);
                $('#LicenciaV').val(response.no_licencia);
                $('#DiscoV').val(response.sdd_hdd);
                $('#MemoriaRAMV').val(response.memoria_ram);
                $('#CargadorV').val(response.cable_cargador);
                $('#NoPantallaV').val(response.no_pantalla);
                $('#ModeloPantallaV').val(response.modelo_pantalla);
                $('#NoTecladoV').val(response.no_teclado);
                $('#ModeloTecladoV').val(response.modelo_teclado);
                $('#NoMouseV').val(response.no_mouse);
                $('#ModeloMouseV').val(response.modelo_mouse);
                $('#AntenaV').val(response.antena);
                $('#DiscoExternoV').val(response.disco_externo);
                $('#MaletinV').val(response.maletin);
                $('#OtrosV').val(response.otros);
                $('#LANV').val(response.mac_lan);
                $('#WLANV').val(response.mac_wlan);
                $('#IPV').val(response.direccion_ip);
                $('#TeamViewerV').val(response.teamviewer);
                $('#AnyDeskV').val(response.anydesk);


            },
            error: function () {
                alert('Error al obtener los datos del Empleado');
            }
        });
    });

});


function mostrarAlerta(tipo, mensaje) {
    var toast = $('<div class="toast align-items-center text-white bg-' + tipo + ' border-0" role="alert" aria-live="assertive" aria-atomic="true">' +
        '<div class="d-flex">' +
        '<div class="toast-body">' + mensaje + '</div>' +
        '<button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>' +
        '</div>' +
        '</div>');

    $('#liveToastContainer').append(toast);

    var bsToast = new bootstrap.Toast(toast[0]);
    bsToast.show();

    // Eliminar el toast después de 5 segundos
    setTimeout(function () {
        bsToast.hide();
    }, 5000);
}

// Función para guardar la alerta en el almacenamiento local del navegador
function guardarAlertaEnAlmacenamiento(tipo, mensaje) {
    var alertasGuardadas = JSON.parse(localStorage.getItem('alertas')) || [];
    alertasGuardadas.push({ tipo: tipo, mensaje: mensaje });
    localStorage.setItem('alertas', JSON.stringify(alertasGuardadas));
}

// Función para cargar las alertas almacenadas y mostrarlas en la página
function cargarAlertas() {
    var alertasGuardadas = JSON.parse(localStorage.getItem('alertas')) || [];
    alertasGuardadas.forEach(function (alerta) {
        mostrarAlerta(alerta.tipo, alerta.mensaje);
    });
    localStorage.removeItem('alertas'); // Eliminar las alertas después de mostrarlas
}



// Función para mostrar el preloader
function showSpinner() {
    $('.preloader').show();
}

// Función para ocultar el preloader
function hideSpinner() {
    $('.preloader').hide();
}

document.addEventListener("DOMContentLoaded", function () {
    // Ocultar el preloader después de que la página se haya cargado completamente
    hidePreloader();
});

// Función para ocultar el preloader
function hidePreloader() {
    document.querySelector(".preloader").style.display = "none";
}