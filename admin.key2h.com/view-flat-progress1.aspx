<%@ Page Title="" Language="C#" MasterPageFile="AdminKey2h.master" AutoEventWireup="true" CodeFile="view-flat-progress.aspx.cs" Inherits="adminkey2hcom_ViewFlatProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <div class="content">
                <div class="panel-header bg-primary-gradient">
                    <div class="page-inner py-5">
                        <div class="d-flex pb-2 align-items-left align-items-sm-center flex-column flex-sm-row justify-content-between">
                            <div class="d-flex">
                                <h2 class="text-white mb-0 fw-bold text-uppercase">View Flat Progress</h2>
                                <ul class="breadcrumbs">
                                    <li class="nav-home pt-1">
                                        <a href="dashboard.html">
                                            <i class="fa fa-home"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div> 
                        </div>
                    </div>
                </div>
                <div class="page-inner mt--5">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card"> 
                                <div class="card-body"> 
                                    <div class="form-group p-0"> 
                                        <div class="row mb-4"> 
                                            <div class="col-sm-4 col-lg-2 pt-3">
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Project Name </label>
                                                    <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                    <asp:DropDownList class="bs-select form-control input-sm" ID="ddlprojects" runat="server">
                                                        <asp:ListItem> </asp:ListItem> 
                                                    </asp:DropDownList>
                                                </div>
                                            </div>  
                                              <div class="col-sm-4 col-lg-2 pt-3">
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Block Name </label>
                                                    <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                    <asp:DropDownList class="bs-select form-control input-sm" ID="ddlBlockName" runat="server">
    <asp:ListItem Value="All">All</asp:ListItem>
                                                        <asp:ListItem>a</asp:ListItem>
    <asp:ListItem>b</asp:ListItem>
    <asp:ListItem>c</asp:ListItem>
</asp:DropDownList>
                                                </div>
                                            </div>  
                                                                                                                                    <div class="col-sm-4 col-lg-2 pt-3">
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Flat Number </label>
                                                    <i class="bi bi-journal-bookmark-fill b5-icon"></i>
                                                    <asp:DropDownList class="bs-select form-control input-sm" ID="ddlFlatNumber" runat="server">
    <asp:ListItem Value="All">All</asp:ListItem>
    <asp:ListItem>23</asp:ListItem>
    <asp:ListItem>24</asp:ListItem>
</asp:DropDownList>
                                                </div>
                                            </div>  
                                            
                                            <div class="col-sm-4 col-lg-2 pt-3">
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Month </label>
                                                    <i class="bi bi-calendar-week b5-icon"></i>
                                                    <asp:DropDownList class="bs-select form-control input-sm" ID="ddlmonth" runat="server"> 
  <asp:ListItem Value="All">All</asp:ListItem>
                                                        <asp:ListItem Value="January">January</asp:ListItem>
    <asp:ListItem Value="February">February</asp:ListItem>
    <asp:ListItem Value="March">March</asp:ListItem>
    <asp:ListItem Value="April">April</asp:ListItem>
    <asp:ListItem Value="May">May</asp:ListItem>
    <asp:ListItem Value="June">June</asp:ListItem>
    <asp:ListItem Value="July">July</asp:ListItem>
    <asp:ListItem Value="August">August</asp:ListItem>
    <asp:ListItem Value="September">September</asp:ListItem>
    <asp:ListItem Value="October">October</asp:ListItem>
    <asp:ListItem Value="November">November</asp:ListItem>
    <asp:ListItem Value="December">December</asp:ListItem>
</asp:DropDownList>
                                                 
                                                </div> 
                                            </div>
                                            <div class="col-sm-4 col-lg-2 pt-3">
                                                <div class="input-icon input-icon-sm right">
                                                    <label>Year  </label>
                                                    <i class="bi bi-calendar-week b5-icon"></i>
                                                    <asp:DropDownList class="bs-select form-control input-sm" ID="ddlyear" runat="server"> 
    <asp:ListItem Value="All">All</asp:ListItem>
    <asp:ListItem Value="2024">2024</asp:ListItem>
    <asp:ListItem Value="2025">2025</asp:ListItem>
    <asp:ListItem Value="2026">2026</asp:ListItem>
    <asp:ListItem Value="2027">2027</asp:ListItem>
    <asp:ListItem Value="2028">2028</asp:ListItem>
    <asp:ListItem Value="2029">2029</asp:ListItem>
    <asp:ListItem Value="2030">2030</asp:ListItem>
</asp:DropDownList>
                                                </div> 
                                            </div>
                                            
                                            <div class="col-sm-2 pt-3 d-flex add-bs-1"> 
                                                <div class="b5-icon-reset" data-bs-toggle="tooltip" title="Reset"> 
                                                    <i class="bi bi-repeat"></i>
                                                </div>
                                            </div>
                                            
                                            
                                        </div>

                                        <h5><span class="box-b-only p-1">Total no. of Count : 5</span></h5>
                                    </div>
                                    <div class="table-responsive">
                                        <table class="table table-bordered">
                                          <thead>
                                            <tr>
                                              <th class="w-sno">#</th>
                                              <th class="min-w-120">Project Name </th>
                                              <th class="min-w-120">Block No. </th>
                                              <th class="min-w-120">Flat No. </th>
                                              <th class="min-w-120">Month / Year</th>  
                                              <th class="min-w-120">Action </th> 
                                          </tr>
                                      </thead>
                                      <tbody>
                                        <tr>
                                          <td>1</td>
                                          <td>Project 1</td>
                                          <td>Block 1</td>
                                          <td>12, 13, 45</td>
                                          <td>Nov / 2024</td>   
                                        <td> 
                                                                                   <a href="add-project-progress.html"  class="me-3">
                                <i class="bi bi-pencil-square b5-icon-et-dlt" data-bs-toggle="tooltip" title="Edit"></i>
                               </a> 
                            <a class="swtAltCancel" >
        <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
</a>
                                        </td> 
                                    </tr>
                                    <tr>
                                      <td>2</td>
                                      <td>Project 2</td> 
                                        <td>Block 2</td>
<td>12</td>
                                      <td>Dec / 2024</td> 
                                    <td> 
                                        <a href="add-project-progress.html"  class="me-3">
                                <i class="bi bi-pencil-square b5-icon-et-dlt" data-bs-toggle="tooltip" title="Edit"></i>
                               </a> 
                            <a class="swtAltCancel">
        <i class="bi bi-trash b5-icon-et-dlt" data-bs-toggle="tooltip" title="Delete"></i>
</a>
                                    </td> 
                                </tr>
                                

                            </tbody>
                        </table>
                    </div>


                </div> 

            </div>
        </div>
    </div>
</div>

</div>
<footer class="footer">
    <div class="container-fluid">
        <nav class="pull-left">
            &copy;
            <script type="text/javascript">
                var today = new Date()
                var year = today.getFullYear()
                document.write(year)
            </script>
        </nav>
        <div class="copyright ml-auto">
            Powered by <a class="text-uppercase" href="https://duffldigital.com/" target="_blank">Duffl
            Digital</a>
        </div>
    </div>
</footer>

    <script>

        // Select the Delete button with the class 'swtAltDelete'
        const buttons = document.querySelectorAll('.swtAltCancel');

        buttons.forEach(function (button) {
            button.addEventListener('click', function () {
                Swal.fire({
                    title: 'Are you sure?',
                    text: 'Do you really want to delete this flat progress? This action cannot be undone!',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#d33', // Red for delete
                    cancelButtonColor: '#3085d6', // Blue for cancel
                    confirmButtonText: 'Yes, Delete It!',
                    cancelButtonText: 'Cancel',
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Logic to delete the customer
                        Swal.fire({
                            icon: 'success',
                            title: 'Deleted!',
                            text: 'The flat progress has been deleted successfully.',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'OK',
                        });
                    }
                });
            });
        });
        </script>
</asp:Content>

