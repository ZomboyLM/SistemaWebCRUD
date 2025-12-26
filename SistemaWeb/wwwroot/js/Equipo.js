

$(document).ready(function () {

    $('#NuevoModal').on('hidden.bs.modal', function (e) {
        // Establece los valores de los campos de entrada como cadenas vacías
   
        $('#NombreN').val('');
        $('#Service_tagN').val('');
        $('#ModeloN').val('');
        $('#TipoequipoN').val('');
        $('#DominioN').val('');
        $('#EstatusN').val($('#EstatusN option:first').val());
        $('#ResguardoN').prop('disabled', true);
        $('#ResguardoN').val('5');
        $('#ActivoFijoN').val('');
        $('#IniGarantiaN').val('');
        $('#FinGarantiaN').val('');
        $('#FechaAdquisionN').val('');
        $('#MarcaN').val('');
        $('#SistemaOperativoN').val('');
        $('#ProcesadorN').val($('#ProcesadorN option:first').val());
        $('#OfficeVersionN').val($('#OfficeVersionN option:first').val());
        $('#LicenciaN').val('');
        $('#DiscoN').val('');
        $('#MemoriaRAMN').val($('#MemoriaRAMN option:first').val());
        $('#CableCargadorN').val('');
        $('#NoPantallaN').val('');
        $('#ModeloPantallaN').val('');
        $('#NoTecladoN').val('');
        $('#ModeloTecladoN').val('');
        $('#NoMouseN').val('');
        $('#ModeloMouseN').val('');
        $('#AntenaN').val('');
        $('#DiscoExternoN').val('');
        $('#MaletinN').val('');
        $('#OtrosN').val('');
        $('#MacLANN').val('');
        $('#MacWLANN').val('');
        $('#DireccionIPN').val('');
        $('#AnyDeskN').val('');
        $('#TeamViewerN').val('');
    });
    var idUsuarios; // Declarar idUsuario fuera de la función de clic del botón

    cargarAlertas();
    var idEquipoTemp; // Variable para almacenar temporalmente el valor de IdUsuario

    // Captura el evento click del botón de Visualizar
    $('#datatablesSimple').on('click', '.btn-info', function () {
        var idEquipo = $(this).data('id'); // Obtén el ID de equipo de la fila seleccionada

        idEmpleadoTemp = idEquipo; // Almacena el valor de IdUsuario temporalmente

        // Hacer una solicitud AJAX para obtener los datos del usuario
        $.ajax({
            url: '/Equipo/ObtenerEquipo', // URL de tu controlador que obtiene los datos del usuario
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


 


    //Obten los datos para poder mostraros en el apartado de editar
    $('#datatablesSimple').on('click', '.btn-success', function () {
        var idEquipo = $(this).data('id'); // Obtén el ID de equipo de la fila seleccionada

        idEquipoTemp = idEquipo; // Almacena el valor de IdUsuario temporalmente

        // Hacer una solicitud AJAX para obtener los datos del usuario
        $.ajax({
            url: '/Equipo/ObtenerEquipo2', // URL de tu controlador que obtiene los datos del usuario
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

                //SE LE AÑADIO EL SETTIMEOUT DEBIDO A QUE NO CARGABA CON TIEMPO LA PAGINA
                setTimeout(function () {
                    if (response.empleado.trim() === "") {
                        // Seleccionar automáticamente la primera opción del select si el valor es una cadena vacía
                        $('#EmpleadoE').val($('#EmpleadoE option:first').val());
                    } else {
                        // Establecer el valor obtenido del servidor
                        $('#EmpleadoE').val(response.empleado);
                    }
                }, 100);

                // Asignar la fecha formateada al input de tipo date
                $('#FechaAdquisionE').val(fechaFormateada);
                $('#IniGarantiaE').val(fechaFormateada2);
                $('#FinGarantiaE').val(fechaFormateada3);

                $('#EmpleadoE').val(response.empleado);
                $('#ResponsivaE').val(response.responsiva + 'C');
                $('#NombreE').val(response.nombre);
                $('#Service_tagE').val(response.service_tag);
                $('#ModeloE').val(response.modelo);
                $('#TipoequipoE').val(response.tipo_equipo);
                $('#DominioE').val(response.dominio);
                $('#EstadoE').val(response.estado);
                $('#ResguardoE').val(response.resguardo);
                $('#ActivoFijoE').val(response.activo_fijo);
                $('#MarcaE').val(response.marca);
                $('#SistemaOperativoE').val(response.sistema_operativo);
                $('#ProcesadorE').val(response.procesador);
                $('#OfficeVersionE').val(response.office_version);
                $('#LicenciaE').val(response.no_licencia);
                $('#DiscoE').val(response.sdd_hdd);
                $('#MemoriaRAME').val(response.memoria_ram);
                $('#CableCargadorE').val(response.cable_cargador);
                $('#NoPantallaE').val(response.no_pantalla);
                $('#ModeloPantallaE').val(response.modelo_pantalla);
                $('#NoTecladoE').val(response.no_teclado);
                $('#ModeloTecladoE').val(response.modelo_teclado);
                $('#NoMouseE').val(response.no_mouse);
                $('#ModeloMouseE').val(response.modelo_mouse);
                $('#AntenaE').val(response.antena);
                $('#DiscoExternoE').val(response.disco_externo);
                $('#MaletinE').val(response.maletin);
                $('#OtrosE').val(response.otros);
                $('#MacLANE').val(response.mac_lan);
                $('#MacWLANE').val(response.mac_wlan);
                $('#DireccionIPE').val(response.direccion_ip);
                $('#TeamViewerE').val(response.teamviewer);
                $('#AnyDeskE').val(response.anydesk);


            },
            error: function () {
                alert('Error al obtener los datos del Equipo');
            }
        });
    });

    //Editar Funcion Select
    // ESTA FUNCION ES DIFERENTE A LA DE INSERTA DEBIDO A QUE ALGUN COMPONENTE LLEGA A INTERFERIR POR ALGUNA EXTRAÑA RAZON
    window.addEventListener('load', function () {
        console.log('DOMContentLoaded event fired');
        var estatusSelect = document.getElementById('EstadoE');
        var resguardoSelect = document.getElementById('ResguardoE');

        estatusSelect.addEventListener('change', function () {
            var estatusSeleccionado = this.value;

            if (estatusSeleccionado === '2') {
                resguardoSelect.disabled = false;
            } else {
                resguardoSelect.disabled = true;
                resguardoSelect.value = '5';
            }
        });

        if (estatusSelect.value !== '2') {
            resguardoSelect.value = '5';
        }
    });


    $('#EditarModal').on('hidden.bs.modal', function () {
        idEquipoTemp = null; // Restablece el valor de idUsuarioTemp al cerrar el modal
    });

    function obtenerIdEstatusE() {
        var selectEstatus = $('#EstadoE');
        return selectEstatus.val();
    }

    function obtenerIdResguardoE() {
        var selectResguardo = $('#ResguardoE');
        return selectResguardo.val();
    }

    $('#btnGuardarCambiosE').on('click', function () {
        showSpinner();
        var idEquipo = idEquipoTemp; // Obtén el valor almacenado en idUsuarioTemp

        var empleado = $('#EmpleadoE').val();
        var responsiva = $('#ResponsivaE').val().trim().replace(/C$/, '');
        if (!responsiva) {
            responsiva = '1'; // Asigna 1 si responsiva es nulo o vacío
        }
        var nombre = $('#NombreE').val().trim();
        var servicetag = $('#Service_tagE').val().trim();
        var modelo = $('#ModeloE').val().trim();
        var tipoequipo = $('#TipoequipoE').val().trim();
        var dominio = $('#DominioE').val().trim();
        var estado = obtenerIdEstatusE();
        var resguardo = obtenerIdResguardoE();
        var activofijo = $('#ActivoFijoE').val().trim();
        var inigarantia = $('#IniGarantiaE').val().trim();
        var fingarantia = $('#FinGarantiaE').val().trim();
        var fechaadquision = $('#FechaAdquisionE').val().trim();
        var marca = $('#MarcaE').val().trim();
        var sistemaoperativo = $('#SistemaOperativoE').val().trim();
        var procesador = $('#ProcesadorE').val();
        var officeversion = $('#OfficeVersionE').val();
        var nolicencia = $('#LicenciaE').val().trim();
        var sddhdd = $('#DiscoE').val().trim();
        var memoriaram = $('#MemoriaRAME').val();
        var cablecargador = $('#CableCargadorE').val().trim();
        var nopantalla = $('#NoPantallaE').val().trim();
        var modelopantalla = $('#ModeloPantallaE').val().trim();
        var noteclado = $('#NoTecladoE').val().trim();
        var modeloteclado = $('#ModeloTecladoE').val().trim();
        var nomouse = $('#NoMouseE').val().trim();
        var modelomouse = $('#ModeloMouseE').val().trim();
        var antena = $('#AntenaE').val().trim();
        var discoexterno = $('#DiscoExternoE').val().trim();
        var maletin = $('#MaletinE').val().trim();
        var otros = $('#OtrosE').val().trim();
        var maclan = $('#MacLANE').val().trim();
        var macwlan = $('#MacWLANE').val().trim();
        var direccionip = $('#DireccionIPE').val().trim();
        var teamviwer = $('#TeamViewerE').val().trim();
        var anydesk = $('#AnyDeskE').val().trim();

        if (nombre === '' || servicetag === '' || modelo === ''
            || tipoequipo === '' || dominio === '' || activofijo === '' || inigarantia === '' || fingarantia === ''
            || fechaadquision === '' || marca === '' || sistemaoperativo === null || procesador === null
            || officeversion === '' || nolicencia === '' || sddhdd === '' || memoriaram === null || cablecargador === ''
            || nopantalla === '' || modelopantalla === '' || noteclado === '' || modeloteclado === '' || nomouse === ''
            || modelomouse === '' || antena === '' || discoexterno === '' || maletin === '' || otros === '' || maclan === '' || macwlan === ''
            || direccionip === '' || teamviwer === '' || anydesk === '' || estado === null) {

            mostrarAlerta3('danger', 'Por favor, completa todos los campos.');
            hideSpinner();
            return;
        }

        // Hacer una solicitud AJAX para actualizar los datos del usuario
        $.ajax({
            url: '/Equipo/ActualizarEquipo', // URL de tu controlador para actualizar usuario
            type: 'POST',
            data: {
                Id_Equipo: idEquipo, // Corrige el nombre del campo aquí
                Nombre: nombre,
                Service_tag: servicetag,
                Modelo: modelo,
                Tipo_equipo: tipoequipo,
                Dominio: dominio,
                Estado: estado,
                Resguardo: resguardo,
                Activo_fijo: activofijo,
                Inicio_garantia: inigarantia,
                Fin_garantia: fingarantia,
                Fecha_adquision: fechaadquision,
                Marca: marca,
                Sistema_operativo: sistemaoperativo,
                Procesador: procesador,
                Office_version: officeversion,
                No_licencia: nolicencia,
                Sdd_hdd: sddhdd,
                Memoria_ram: memoriaram,
                Cable_cargador: cablecargador,
                No_pantalla: nopantalla,
                Modelo_pantalla: modelopantalla,
                No_teclado: noteclado,
                Modelo_teclado: modeloteclado,
                No_mouse: nomouse,
                Modelo_mouse: modelomouse,
                Antena: antena,
                Disco_externo: discoexterno,
                Maletin: maletin,
                Otros: otros,
                Mac_lan: maclan,
                Mac_wlan: macwlan,
                Direccion_ip: direccionip,
                Teamviewer: teamviwer,
                Anydesk: anydesk,
                Empleado: empleado,
                Responsiva: responsiva
            },
            success: function (response) {
                if (response.success) {
                    guardarAlertaEnAlmacenamiento('success', response.message);
                    window.location.reload();

                    // Restablecer los campos del formulario

                    $('#NombreE').val('');
                    $('#Service_tagE').val('');
                    $('#ModeloE').val('');
                    $('#TipoequipoE').val('');
                    $('#DominioE').val('');
                    $('#EstatusE').val($('#EstatusE option:first').val());
                    $('#ResguardoE').prop('disabled', true);
                    $('#ResguardoE').val('5');
                    $('#ActivoFijoE').val('');
                    $('#IniGarantiaE').val('');
                    $('#FinGarantiaE').val('');
                   
                    $('#FechaAdquisionE').val('');
                    $('#MarcaE').val('');
                    $('#SistemaOperativoE').val('');
                    $('#ProcesadorE').val('');
                    $('#OfficeVersionE').val('');
                    $('#LicenciaE').val('');
                    $('#DiscoE').val('');
                    $('#MemoriaRAME').val('');
                    $('#CableCargadorE').val('');
                    $('#NoPantallaE').val('');
                    $('#ModeloPantallaE').val('');
                    $('#NoTecladoE').val('');
                    $('#ModeloTecladoE').val('');
                    $('#NoMouseE').val('');
                    $('#ModeloMouseE').val('');
                    $('#AntenaE').val('');
                    $('#DiscoExternoE').val('');
                    $('#MaletinE').val('');
                    $('#OtrosE').val('');
                    $('#MacLANE').val('');
                    $('#MacWLANE').val('');
                    $('#DireccionIPE').val('');
                    $('#AnyDeskE').val('');
                    $('#TeamViewerE').val('');

                    // Eliminar la alerta después de un tiempo
                    setTimeout(function () {
                        successAlert.remove();

                    }, 5000); // Eliminar la alerta después de 3 segundos
                    actualizarTablaUsuarios();
                } else {
                    guardarAlertaEnAlmacenamiento('danger', response.message);
                    window.location.reload();
                }
            },
            error: function () {
                guardarAlertaEnAlmacenamiento('danger', 'Error Con el servidor');
                window.location.reload();
            },
            complete: function () {
                hideSpinner();
            }
        });
    });
    //nf
});

function mostrarAlerta2(tipo, mensaje) {
    var toast = $('<div class="toast align-items-center text-white bg-' + tipo + ' border-0" role="alert" aria-live="assertive" aria-atomic="true">' +
        '<div class="d-flex">' +
        '<div class="toast-body">' + mensaje + '</div>' +
        '<button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>' +
        '</div>' +
        '</div>');

    $('#liveToastContainer2').append(toast);

    var bsToast = new bootstrap.Toast(toast[0]);
    bsToast.show();

    // Eliminar el toast después de 5 segundos
    setTimeout(function () {
        bsToast.hide();
    }, 5000);
}

function mostrarAlerta3(tipo, mensaje) {
    var toast = $('<div class="toast align-items-center text-white bg-' + tipo + ' border-0" role="alert" aria-live="assertive" aria-atomic="true">' +
        '<div class="d-flex">' +
        '<div class="toast-body">' + mensaje + '</div>' +
        '<button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>' +
        '</div>' +
        '</div>');

    $('#liveToastContainer3').append(toast);

    var bsToast = new bootstrap.Toast(toast[0]);
    bsToast.show();

    // Eliminar el toast después de 5 segundos
    setTimeout(function () {
        bsToast.hide();
    }, 5000);
}

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


/*GUARDAR LOS DATOS*/


//Select Guardar
document.addEventListener('DOMContentLoaded', function () {
    var estatusSelect = document.getElementById('EstatusN');
    var resguardoSelect = document.getElementById('ResguardoN');

    estatusSelect.addEventListener('change', function () {
        var estatusSeleccionado = this.value;

        if (estatusSeleccionado === '2') {
            resguardoSelect.disabled = false;
        } else {
            resguardoSelect.disabled = true;
            resguardoSelect.value = '5'; 
        }
    });

    if (estatusSelect.value !== '2') {
        resguardoSelect.value = '5';
    }
});



function obtenerIdEstatus() {
    var selectEstatus = $('#EstatusN');
    return selectEstatus.val();
}

function obtenerIdResguardo() {
    var selectResguardo = $('#ResguardoN');
    return selectResguardo.val();
}

$('#btnGuardarCambiosN').on('click', function () {
    showSpinner();
    var nombre = $('#NombreN').val().trim();
    var servicetag = $('#Service_tagN').val().trim();
    var modelo = $('#ModeloN').val().trim();
    var tipoequipo = $('#TipoequipoN').val().trim();
    var dominio = $('#DominioN').val().trim();
    var estado = obtenerIdEstatus();
    var resguardo = obtenerIdResguardo();
    var activofijo = $('#ActivoFijoN').val().trim();
    var inigarantia = $('#IniGarantiaN').val().trim(); 
    var fingarantia = $('#FinGarantiaN').val().trim();
    var fechaadquision = $('#FechaAdquisionN').val().trim();
    var marca = $('#MarcaN').val().trim();
    var sistemaoperativo = $('#SistemaOperativoN').val().trim();
    var procesador = $('#ProcesadorN').val();
    var officeversion = $('#OfficeVersionN').val();
    var nolicencia = $('#LicenciaN').val().trim();
    var sddhdd = $('#DiscoN').val().trim();
    var memoriaram = $('#MemoriaRAMN').val();
    var cablecargador = $('#CableCargadorN').val().trim();
    var nopantalla = $('#NoPantallaN').val().trim();
    var modelopantalla = $('#ModeloPantallaN').val().trim();
    var noteclado = $('#NoTecladoN').val().trim();
    var modeloteclado = $('#ModeloTecladoN').val().trim();
    var nomouse = $('#NoMouseN').val().trim();
    var modelomouse = $('#ModeloMouseN').val().trim();
    var antena = $('#AntenaN').val().trim();
    var discoexterno = $('#DiscoExternoN').val().trim();
    var maletin = $('#MaletinN').val().trim();
    var otros = $('#OtrosN').val().trim();
    var maclan = $('#MacLANN').val().trim();
    var macwlan = $('#MacWLANN').val().trim();
    var direccionip = $('#DireccionIPN').val().trim();
    var teamviwer = $('#TeamViewerN').val().trim();
    var anydesk = $('#AnyDeskN').val().trim();

    if (nombre === '' || servicetag === '' || modelo === ''
        || tipoequipo === '' || dominio === '' || activofijo === '' || inigarantia === '' || fingarantia === ''
        || fechaadquision === '' || marca === '' || sistemaoperativo === '' || procesador === null
        || officeversion === null || nolicencia === '' || sddhdd === '' || memoriaram === null || cablecargador === ''
        || nopantalla === '' || modelopantalla === '' || noteclado === '' || modeloteclado === '' || nomouse === ''
        || modelomouse === '' || antena === '' || discoexterno === '' || maletin === '' || otros === '' || maclan === '' || macwlan === ''
        || direccionip === ''|| teamviwer === '' || anydesk=== ''  || estado === null  ) {

        mostrarAlerta2('danger', 'Por favor, completa todos los campos.');
        hideSpinner();
        return;
    }

    var datos = {
        Nombre: nombre,
        Service_tag: servicetag,
        Modelo: modelo,
        Tipo_equipo: tipoequipo,
        Dominio: dominio,
        Estado: estado,
        Resguardo: resguardo,
        Activo_fijo: activofijo,
        Inicio_garantia: inigarantia,
        Fin_garantia: fingarantia,
        Fecha_adquision: fechaadquision,
        Marca: marca,
        Sistema_operativo: sistemaoperativo,
        Procesador: procesador,
        Office_version: officeversion,
        No_licencia: nolicencia,
        Sdd_hdd: sddhdd,
        Memoria_ram: memoriaram,
        Cable_cargador: cablecargador,
        No_pantalla: nopantalla,
        Modelo_pantalla: modelopantalla,
        No_teclado: noteclado,
        Modelo_teclado: modeloteclado,
        No_mouse: nomouse,
        Modelo_mouse: modelomouse,
        Antena: antena,
        Disco_externo: discoexterno,
        Maletin: maletin,
        Otros: otros,
        Mac_lan: maclan,
        Mac_wlan: macwlan,
        Direccion_ip: direccionip,
        Teamviewer: teamviwer,
        Anydesk: anydesk
    };

    $.ajax({
        url: '/Equipo/Guardar',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos),
        success: function (response) {
            if (response.success) {
                guardarAlertaEnAlmacenamiento('success', response.message);
                setTimeout(function () {
                    window.location.reload();
                }, 3000); // Recargar la página después de 3 segundos
            } else {
                guardarAlertaEnAlmacenamiento('danger', response.message);
            }
        },
        error: function () {
            guardarAlertaEnAlmacenamiento('danger', 'Error al conectar con el servidor');
        }
    });
});



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