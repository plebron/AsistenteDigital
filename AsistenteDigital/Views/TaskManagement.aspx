<%@ Page Title="Tareas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskManagement.aspx.cs" Inherits="AsistenteDigital._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Container">
        
        <h2>Administracion de tareas</h2>
        <p>Resumen de tareas registradas</p>

        <table class="table table-striped table-hover">
            <thead>
                <tr class="thead-light">
                    <th>ID</th>
                    <th>Titulo</th>
                    <th>Descripcion</th>
                    <th>Estado</th>
                    <th>Fecha de Creacion</th>
                    <th>Fecha de finalizacion</th>
                </tr>
            </thead>
            <tr>
                <td>01</td>
                <td>Crear Ejemplo de tabla</td>
                <td>Crear Ejemplo de tabla</td>
                <td>Pendiente</td>
                <td>2018-06-16</td>
                <td>2018-06-16</td>
            </tr>
            <tr>
                <td>02</td>
                <td>Crear Base de Datos</td>
                <td>Crear Base de Datos</td>
                <td>En proceso</td>
                <td>2018-06-16</td>
                <td>2018-06-23</td>
            </tr>
        </table>
    </div>

</asp:Content>