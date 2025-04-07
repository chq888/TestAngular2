import 'package:flutter/material.dart';
import 'package:syncfusion_flutter_datagrid/datagrid.dart';


/// The application that contains datagrid on it.
class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Syncfusion DataGrid Demo',
      theme: ThemeData(useMaterial3: false),
      home: MyHomePage(),
    );
  }
}

/// The home page of the application which hosts the datagrid.
class MyHomePage extends StatefulWidget {
  /// Creates the home page.
  const MyHomePage({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<Employee> employees = <Employee>[];
  late EmployeeDataSource employeeDataSource;

  @override
  void initState() {
    super.initState();
    employees = getEmployeeData();
    employeeDataSource = EmployeeDataSource(
      employeeData: employees,
// ...existing code...
onView: (employee) {
  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0), // Material 3 rounded corners
        ),
        child: LayoutBuilder(
          builder: (BuildContext context, BoxConstraints constraints) {
            final screenWidth = MediaQuery.of(context).size.width;
            final screenHeight = MediaQuery.of(context).size.height;

            // Calculate the dialog width and height
            final dialogWidth = screenWidth * 0.9 > 500.0
                ? 500.0 // Default width if screen width allows
                : screenWidth * 0.9; // 90% of the screen width for smaller screens
            final dialogHeight = screenHeight * 0.9;

            return ConstrainedBox(
              constraints: BoxConstraints(
                minWidth: 250, // Minimum width for the dialog
                maxWidth: dialogWidth, // Maximum width for the dialog
                maxHeight: dialogHeight, // Maximum height for the dialog
              ),
              child: Padding(
                padding: const EdgeInsets.all(24.0),
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      // Header with icon and title
                      Row(
                        children: [
                          Icon(Icons.person, color: Theme.of(context).colorScheme.primary, size: 32),
                          SizedBox(width: 16),
                          Text(
                            'Employee Details',
                            style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                                  fontWeight: FontWeight.bold,
                                ),
                          ),
                        ],
                      ),
                      SizedBox(height: 16),
                      Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                      SizedBox(height: 16),

                      // Employee details in a 2-column layout
                      Row(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          // First column: ID and Name
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                _buildDetailField(context, 'ID', '${employee.id}'),
                                _buildDetailField(context, 'Name', employee.name),
                              ],
                            ),
                          ),
                          SizedBox(width: 16), // Space between columns
                          // Second column: Designation and Salary
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                _buildDetailField(context, 'Designation', employee.designation),
                                _buildDetailField(context, 'Salary', '\$${employee.salary}'),
                              ],
                            ),
                          ),
                        ],
                      ),

                      SizedBox(height: 16),
                      Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),

                      // Roles and Permissions
                      Text(
                        'Roles and Permissions',
                        style: Theme.of(context).textTheme.titleMedium?.copyWith(
                              fontWeight: FontWeight.bold,
                              color: Theme.of(context).colorScheme.primary,
                            ),
                      ),
                      SizedBox(height: 8),
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: _buildRolesAndPermissions(context, employee.roles, employee.permissions),
                      ),

                      SizedBox(height: 24),
                      Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),

                      // Close button with icon
                      Align(
                        alignment: Alignment.centerRight,
                        child: FilledButton.icon(
                          style: FilledButton.styleFrom(
                            backgroundColor: Theme.of(context).colorScheme.primary,
                            foregroundColor: Theme.of(context).colorScheme.onPrimary,
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(12.0),
                            ),
                          ),
                          icon: Icon(Icons.close),
                          label: Text('Close'),
                          onPressed: () => Navigator.of(context).pop(),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            );
          },
        ),
      );
    },
  );
},
    );
  }
List<Widget> _buildRolesAndPermissions(
    BuildContext context, List<String> roles, List<String> permissions) {
  return roles.map((role) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            role,
            style: Theme.of(context).textTheme.bodyLarge?.copyWith(
                  fontWeight: FontWeight.bold,
                  color: Theme.of(context).colorScheme.onSurface,
                ),
          ),
          SizedBox(height: 4),
          Padding(
            padding: const EdgeInsets.only(left: 16.0),
            child: Text(
              permissions.join(', '),
              style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                    color: Theme.of(context).colorScheme.onSurfaceVariant,
                  ),
            ),
          ),
        ],
      ),
    );
  }).toList();
}
Widget _buildDetailField(BuildContext context, String label, String value) {
  return Padding(
    padding: const EdgeInsets.symmetric(vertical: 4.0),
    child: Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          '$label: ',
          style: Theme.of(context).textTheme.bodyLarge?.copyWith(
                fontWeight: FontWeight.bold,
                color: Theme.of(context).colorScheme.onSurface,
              ),
        ),
        Expanded(
          child: Text(
            value,
            style: Theme.of(context).textTheme.bodyLarge?.copyWith(
                  color: Theme.of(context).colorScheme.onSurfaceVariant,
                ),
          ),
        ),
      ],
    ),
  );
}


 @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Syncfusion Flutter DataGrid')),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(10.0),
            child: TextButton(
              onPressed: () {
                employeeDataSource._employeeData = [];
                employeeDataSource.notifyListeners();
              },
              child: Text('Clear All'),
            ),
          ),
          Expanded(
            child: SfDataGrid(
              source: employeeDataSource,
              columnWidthMode: ColumnWidthMode.fill,
              placeholder: Center(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Icon(Icons.thumb_down_alt_outlined, size: 30),
                    SizedBox(height: 8),
                    Text('No Records Found', style: TextStyle(fontSize: 16)),
                  ],
                ),
              ),
              columns: <GridColumn>[
                GridColumn(
                  columnName: 'id',
                  label: Container(
                    padding: EdgeInsets.all(16.0),
                    alignment: Alignment.center,
                    child: Text('ID'),
                  ),
                ),
                GridColumn(
                  columnName: 'name',
                  label: Container(
                    padding: EdgeInsets.all(8.0),
                    alignment: Alignment.center,
                    child: Text('Name'),
                  ),
                ),
                GridColumn(
                  columnName: 'designation',
                  label: Container(
                    padding: EdgeInsets.all(8.0),
                    alignment: Alignment.center,
                    child: Text('Designation', overflow: TextOverflow.ellipsis),
                  ),
                ),
                GridColumn(
                  columnName: 'salary',
                  label: Container(
                    padding: EdgeInsets.all(8.0),
                    alignment: Alignment.center,
                    child: Text('Salary'),
                  ),
                ),
                // New Action column
                GridColumn(
                  columnName: 'action',
                  label: Container(
                    padding: EdgeInsets.all(8.0),
                    alignment: Alignment.center,
                    child: Text('Action'),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
 List<Employee> getEmployeeData() {
  return [
    Employee(10001, 'James', 'Project Lead', 20000, ['Admin'], ['Read', 'Write', 'Delete', 'Execute', 'Update', 'Create', 'Modify', 'View', 'Export', 'Import', 'Share', 'Print', 'Download', 'Upload', 'Sync', 'Backup', 'Restore', 'Archive', 'Send', 'Receive', 'Approve', 'Reject', 'Flag', 'Unflag', 'Mark', 'Unmark', 'Pin', 'Unpin', 'Follow', 'Unfollow']),
    Employee(10002, 'Kathryn', 'Manager', 30000, ['Manager'], ['Read', 'Write']),
    Employee(10003, 'Lara', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
    Employee(10004, 'Michael', 'Designer', 15000, ['Designer'], ['Read']),
    Employee(10005, 'Martin', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
    Employee(10006, 'Newberry', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
    Employee(10007, 'Balnc', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
    Employee(10008, 'Perry', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
    Employee(10009, 'Gable', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
    Employee(10010, 'Grimes', 'Developer', 15000, ['Developer'], ['Read', 'Write']),
  ];
}

}

/// Custom business object class which contains properties to hold the detailed
/// information about the employee which will be rendered in datagrid.
class Employee {
  /// Creates the employee class with required details.
  Employee(this.id, this.name, this.designation, this.salary, this.roles, this.permissions);

  /// Id of an employee.
  final int id;

  /// Name of an employee.
  final String name;

  /// Designation of an employee.
  final String designation;

  /// Salary of an employee.
  final int salary;

  /// Roles of an employee.
  final List<String> roles;

  /// Permissions of an employee.
  final List<String> permissions;
}


/// An object to set the employee collection data source to the datagrid. This
/// is used to map the employee data to the datagrid widget.
class EmployeeDataSource extends DataGridSource {
  final void Function(Employee) onView;
  // Constructor updated to accept onView callback and include the new 'action' cell.
  EmployeeDataSource({
    required List<Employee> employeeData,
    required this.onView,
  }) {
    _employeeData = employeeData.map<DataGridRow>(
      (employee) => DataGridRow(
        cells: [
          DataGridCell<int>(columnName: 'id', value: employee.id),
          DataGridCell<String>(columnName: 'name', value: employee.name),
          DataGridCell<String>(
            columnName: 'designation',
            value: employee.designation,
          ),
          DataGridCell<int>(columnName: 'salary', value: employee.salary),
          // New cell for Action button. The value is the employee instance.
          DataGridCell<Employee>(columnName: 'action', value: employee),
        ],
      ),
    ).toList();
  }

  List<DataGridRow> _employeeData = [];

  @override
  List<DataGridRow> get rows => _employeeData;

  @override
  DataGridRowAdapter buildRow(DataGridRow row) {
    return DataGridRowAdapter(
      cells: row.getCells().map<Widget>((cell) {
        if (cell.columnName == 'action') {
          // Display the "View" button for the Action column.
          return Container(
            alignment: Alignment.center,
            padding: EdgeInsets.all(8.0),
    child: IconButton(
      icon: Icon(Icons.visibility, color: Colors.blue),
      tooltip: 'View Details',
      onPressed: () {
        onView(cell.value as Employee);
      },
    ),
          );
        }
        return Container(
          alignment: Alignment.center,
          padding: EdgeInsets.all(8.0),
          child: Text(cell.value.toString()),
        );
      }).toList(),
    );
  }
}