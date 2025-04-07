import 'package:flutter/material.dart';
import 'package:syncfusion_flutter_datagrid/datagrid.dart';

void main() {
  runApp(MyApp());
}

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
final Map<String, List<String>> rolePermissions = {
  'Admin': ['Read', 'Write', 'Delete', 'Execute'],
  'Manager': ['Read', 'Write', 'Approve', 'Reject'],
  'Developer': ['Read', 'Write', 'Modify', 'Debug'],
  'Designer': ['Read', 'Write', 'Design', 'Export'],
};
void _showAssignRolesDialog(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles
  Set<String> openPanels = {}; // Track roles with open permissions panels

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: LayoutBuilder(
          builder: (BuildContext context, BoxConstraints constraints) {
            final screenWidth = MediaQuery.of(context).size.width;
            final screenHeight = MediaQuery.of(context).size.height;

            // Calculate dialog width and height
            final dialogWidth = screenWidth * 0.9 > 600.0 ? 600.0 : screenWidth * 0.9; // Max width: 600px
            final dialogHeight = screenHeight * 0.6; // Reduced height to 60% of screen height

            return ConstrainedBox(
              constraints: BoxConstraints(
                maxWidth: dialogWidth,
                maxHeight: dialogHeight,
              ),
              child: Padding(
                padding: const EdgeInsets.all(24.0),
                child: StatefulBuilder(
                  builder: (BuildContext context, StateSetter setState) {
                    return Column(
                      mainAxisSize: MainAxisSize.min,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          children: [
                            Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                            SizedBox(width: 8),
                            Text(
                              'Assign Roles',
                              style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                                    fontWeight: FontWeight.bold,
                                  ),
                            ),
                          ],
                        ),
                        SizedBox(height: 16),
                        Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                        SizedBox(height: 16),
                        Text(
                          'Select roles to assign to ${employee.name}:',
                          style: Theme.of(context).textTheme.bodyMedium,
                        ),
                        SizedBox(height: 16),
                        Expanded(
                          child: Scrollbar(
                            thumbVisibility: true, // Always show the scrollbar when scrolling
                            radius: Radius.circular(8.0), // Rounded corners for the scrollbar
                            thickness: 6.0, // Thickness of the scrollbar
                            child: ListView(
                              padding: const EdgeInsets.only(right: 12.0), // Add padding to avoid scrollbar overlay
                              shrinkWrap: true,
                              children: availableRoles.map((role) {
                                return Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    GestureDetector(
                                      onTap: () {
                                        setState(() {
                                          if (selectedRoles.contains(role)) {
                                            selectedRoles.remove(role);
                                          } else {
                                            selectedRoles.add(role);
                                          }
                                        });
                                      },
                                      child: Row(
                                        children: [
                                          Checkbox(
                                            value: selectedRoles.contains(role),
                                            onChanged: (bool? value) {
                                              setState(() {
                                                if (value == true) {
                                                  selectedRoles.add(role);
                                                } else {
                                                  selectedRoles.remove(role);
                                                }
                                              });
                                            },
                                          ),
                                          Expanded(
                                            child: Text(
                                              role,
                                              style: Theme.of(context).textTheme.bodyMedium,
                                            ),
                                          ),
                                          IconButton(
                                            icon: Icon(Icons.info_outline, color: Theme.of(context).colorScheme.primary),
                                            tooltip: 'View Permissions',
                                            onPressed: () {
                                              setState(() {
                                                if (openPanels.contains(role)) {
                                                  openPanels.remove(role); // Close the panel
                                                } else {
                                                  openPanels.add(role); // Open the panel
                                                }
                                              });
                                            },
                                          ),
                                        ],
                                      ),
                                    ),
                                    if (openPanels.contains(role)) // Show permissions panel for the selected role
                                      Container(
                                        padding: const EdgeInsets.all(8.0), // Reduced padding
                                        margin: const EdgeInsets.only(bottom: 8.0), // Reduced margin
                                        decoration: BoxDecoration(
                                          color: Theme.of(context).colorScheme.surfaceVariant.withOpacity(0.1),
                                          borderRadius: BorderRadius.circular(8.0), // Smaller border radius
                                          border: Border.all(color: Theme.of(context).colorScheme.primary),
                                        ),
                                        child: ConstrainedBox(
                                          constraints: BoxConstraints(
                                            maxHeight: 100.0, // Limit the height of the permissions panel
                                          ),
                                          child: Scrollbar(
                                            thumbVisibility: true, // Always show the scrollbar when scrolling
                                            radius: Radius.circular(8.0),
                                            thickness: 6.0,
                                            child: ListView(
                                              padding: const EdgeInsets.only(right: 8.0), // Add padding to avoid scrollbar overlay
                                              shrinkWrap: true,
                                              physics: const ClampingScrollPhysics(),
                                              children: rolePermissions[role]!.map((permission) {
                                                return Padding(
                                                  padding: const EdgeInsets.symmetric(vertical: 2.0), // Reduced vertical padding
                                                  child: Row(
                                                    children: [
                                                      Icon(Icons.check, size: 14, color: Theme.of(context).colorScheme.primary), // Smaller icon
                                                      SizedBox(width: 4),
                                                      Text(
                                                        permission,
                                                        style: Theme.of(context).textTheme.bodySmall, // Smaller text
                                                      ),
                                                    ],
                                                  ),
                                                );
                                              }).toList(),
                                            ),
                                          ),
                                        ),
                                      ),
                                  ],
                                );
                              }).toList(),
                            ),
                          ),
                        ),
                        SizedBox(height: 16),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: [
                            // Cancel Button
                            TextButton.icon(
                              style: TextButton.styleFrom(
                                backgroundColor: Theme.of(context).colorScheme.error.withOpacity(0.1), // Add background color
                                foregroundColor: Theme.of(context).colorScheme.error, // Text color
                                padding: const EdgeInsets.symmetric(horizontal: 16.0, vertical: 8.0),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(12.0),
                                ),
                              ),
                              onPressed: () {
                                Navigator.of(context).pop(); // Close the dialog without saving
                              },
                              icon: Icon(Icons.cancel),
                              label: Text(
                                'Cancel',
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                ),
                              ),
                            ),
                            SizedBox(width: 8),
                            // Assign Button
                            FilledButton.icon(
                              style: FilledButton.styleFrom(
                                backgroundColor: Theme.of(context).colorScheme.primary,
                                foregroundColor: Theme.of(context).colorScheme.onPrimary,
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(12.0),
                                ),
                              ),
                              icon: Icon(Icons.check),
                              label: Text('Assign'),
                              onPressed: () {
                                setState(() {
                                  employee.roles.clear();
                                  employee.roles.addAll(selectedRoles); // Update roles
                                });
                                Navigator.of(context).pop();
                              },
                            ),
                          ],
                        ),
                      ],
                    );
                  },
                ),
              ),
            );
          },
        ),
      );
    },
  );
}
  
void _showAssignRolesDialoghhg(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles
  Set<String> openPanels = {}; // Track roles with open permissions panels

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: StatefulBuilder(
            builder: (BuildContext context, StateSetter setState) {
              return Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                      SizedBox(width: 8),
                      Text(
                        'Assign Roles',
                        style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                              fontWeight: FontWeight.bold,
                            ),
                      ),
                    ],
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    'Select roles to assign to ${employee.name}:',
                    style: Theme.of(context).textTheme.bodyMedium,
                  ),
                  SizedBox(height: 16),
                  Expanded(
                    child: ListView(
                      shrinkWrap: true,
                      children: availableRoles.map((role) {
                        return Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Row(
                              children: [
                                Expanded(
                                  child: CheckboxListTile(
                                    title: Text(role),
                                    value: selectedRoles.contains(role),
                                    onChanged: (bool? value) {
                                      setState(() {
                                        if (value == true) {
                                          selectedRoles.add(role);
                                        } else {
                                          selectedRoles.remove(role);
                                        }
                                      });
                                    },
                                  ),
                                ),
                                IconButton(
                                  icon: Icon(Icons.info_outline, color: Theme.of(context).colorScheme.primary),
                                  tooltip: 'View Permissions',
                                  onPressed: () {
                                    setState(() {
                                      if (openPanels.contains(role)) {
                                        openPanels.remove(role); // Close the panel
                                      } else {
                                        openPanels.add(role); // Open the panel
                                      }
                                    });
                                  },
                                ),
                              ],
                            ),
                            if (openPanels.contains(role)) // Show permissions panel for the selected role
                              Container(
                                padding: const EdgeInsets.all(16.0),
                                margin: const EdgeInsets.only(bottom: 16.0),
                                decoration: BoxDecoration(
                                  color: Theme.of(context).colorScheme.surfaceVariant.withOpacity(0.1),
                                  borderRadius: BorderRadius.circular(12.0),
                                  border: Border.all(color: Theme.of(context).colorScheme.primary),
                                ),
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Row(
                                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                      children: [
                                        Text(
                                          'Permissions for $role:',
                                          style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                                                fontWeight: FontWeight.bold,
                                                color: Theme.of(context).colorScheme.primary,
                                              ),
                                        ),
                                        IconButton(
                                          icon: Icon(Icons.close, color: Theme.of(context).colorScheme.primary),
                                          tooltip: 'Close Permissions',
                                          onPressed: () {
                                            setState(() {
                                              openPanels.remove(role); // Close the panel
                                            });
                                          },
                                        ),
                                      ],
                                    ),
                                    SizedBox(height: 8),
                                    ...rolePermissions[role]!.map((permission) {
                                      return Padding(
                                        padding: const EdgeInsets.symmetric(vertical: 4.0),
                                        child: Row(
                                          children: [
                                            Icon(Icons.check, size: 16, color: Theme.of(context).colorScheme.primary),
                                            SizedBox(width: 8),
                                            Text(permission),
                                          ],
                                        ),
                                      );
                                    }).toList(),
                                  ],
                                ),
                              ),
                          ],
                        );
                      }).toList(),
                    ),
                  ),
                  SizedBox(height: 24),
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
                      icon: Icon(Icons.check),
                      label: Text('Assign'),
                      onPressed: () {
                        setState(() {
                          employee.roles.clear();
                          employee.roles.addAll(selectedRoles); // Update roles
                        });
                        Navigator.of(context).pop();
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ),
      );
    },
  );
}
void _showAssignRolesDialoghhh(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles
  String? selectedRole; // Track the currently selected role to display its permissions
  String? infoRole; // Track the role for which the permissions panel is shown

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: StatefulBuilder(
            builder: (BuildContext context, StateSetter setState) {
              return Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                      SizedBox(width: 8),
                      Text(
                        'Assign Roles',
                        style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                              fontWeight: FontWeight.bold,
                            ),
                      ),
                    ],
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    'Select roles to assign to ${employee.name}:',
                    style: Theme.of(context).textTheme.bodyMedium,
                  ),
                  SizedBox(height: 16),
                  Expanded(
                    child: ListView(
                      shrinkWrap: true,
                      children: availableRoles.map((role) {
                        return Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Row(
                              children: [
                                Expanded(
                                  child: CheckboxListTile(
                                    title: Text(role),
                                    value: selectedRoles.contains(role),
                                    onChanged: (bool? value) {
                                      setState(() {
                                        if (value == true) {
                                          selectedRoles.add(role);
                                        } else {
                                          selectedRoles.remove(role);
                                        }
                                        selectedRole = role; // Update the selected role
                                      });
                                    },
                                  ),
                                ),
                                IconButton(
                                  icon: Icon(Icons.info_outline, color: Theme.of(context).colorScheme.primary),
                                  tooltip: 'View Permissions',
                                  onPressed: () {
                                    setState(() {
                                      infoRole = role; // Show permissions panel for this role
                                    });
                                  },
                                ),
                              ],
                            ),
                            if (infoRole == role) // Show permissions panel for the selected role
                              Container(
                                padding: const EdgeInsets.all(16.0),
                                margin: const EdgeInsets.only(bottom: 16.0),
                                decoration: BoxDecoration(
                                  color: Theme.of(context).colorScheme.surfaceVariant.withOpacity(0.1),
                                  borderRadius: BorderRadius.circular(12.0),
                                  border: Border.all(color: Theme.of(context).colorScheme.primary),
                                ),
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Row(
                                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                      children: [
                                        Text(
                                          'Permissions for $role:',
                                          style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                                                fontWeight: FontWeight.bold,
                                                color: Theme.of(context).colorScheme.primary,
                                              ),
                                        ),
                                        IconButton(
                                          icon: Icon(Icons.close, color: Theme.of(context).colorScheme.primary),
                                          tooltip: 'Close Permissions',
                                          onPressed: () {
                                            setState(() {
                                              infoRole = null; // Hide the permissions panel
                                            });
                                          },
                                        ),
                                      ],
                                    ),
                                    SizedBox(height: 8),
                                    ...rolePermissions[role]!.map((permission) {
                                      return Padding(
                                        padding: const EdgeInsets.symmetric(vertical: 4.0),
                                        child: Row(
                                          children: [
                                            Icon(Icons.check, size: 16, color: Theme.of(context).colorScheme.primary),
                                            SizedBox(width: 8),
                                            Text(permission),
                                          ],
                                        ),
                                      );
                                    }).toList(),
                                  ],
                                ),
                              ),
                          ],
                        );
                      }).toList(),
                    ),
                  ),
                  SizedBox(height: 24),
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
                      icon: Icon(Icons.check),
                      label: Text('Assign'),
                      onPressed: () {
                        setState(() {
                          employee.roles.clear();
                          employee.roles.addAll(selectedRoles); // Update roles
                        });
                        Navigator.of(context).pop();
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ),
      );
    },
  );
}
void _showAssignRolesDialogggg(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles
  String? selectedRole; // Track the currently selected role to display its permissions

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: StatefulBuilder(
            builder: (BuildContext context, StateSetter setState) {
              return Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                      SizedBox(width: 8),
                      Text(
                        'Assign Roles',
                        style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                              fontWeight: FontWeight.bold,
                            ),
                      ),
                    ],
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    'Select roles to assign to ${employee.name}:',
                    style: Theme.of(context).textTheme.bodyMedium,
                  ),
                  SizedBox(height: 16),
                  Expanded(
                    child: ListView(
                      shrinkWrap: true,
                      children: availableRoles.map((role) {
                        return CheckboxListTile(
                          title: Text(role),
                          value: selectedRoles.contains(role),
              onChanged: (bool? value) {
          setState(() {
            if (value == true) {
              selectedRoles.add(role);
            } else {
              selectedRoles.remove(role);
            }
            selectedRole = role; // Update the selected role
          });
        },

                        );
                      }).toList(),
                    ),
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    selectedRole != null
                        ? 'Permissions for $selectedRole:'
                        : 'Select a role to view its permissions:',
                    style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                          fontWeight: FontWeight.bold,
                        ),
                  ),
                  SizedBox(height: 8),
                  Expanded(
                    child: selectedRole != null
                        ? ListView(
                            shrinkWrap: true,
                            children: rolePermissions[selectedRole]!
                                .map((permission) => Padding(
                                      padding: const EdgeInsets.symmetric(vertical: 4.0),
                                      child: Row(
                                        children: [
                                          Icon(Icons.check, size: 16, color: Theme.of(context).colorScheme.primary),
                                          SizedBox(width: 8),
                                          Text(permission),
                                        ],
                                      ),
                                    ))
                                .toList(),
                          )
                        : Center(
                            child: Text(
                              'No role selected',
                              style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                                    color: Theme.of(context).colorScheme.onSurfaceVariant,
                                  ),
                            ),
                          ),
                  ),
                  SizedBox(height: 24),
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
                      icon: Icon(Icons.check),
                      label: Text('Assign'),
                      onPressed: () {
                        setState(() {
                          employee.roles.clear();
                          employee.roles.addAll(selectedRoles); // Update roles
                        });
                        Navigator.of(context).pop();
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ),
      );
    },
  );
}



void _showAssignRolesDialogv4(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: StatefulBuilder(
            builder: (BuildContext context, StateSetter setState) {
              return Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                      SizedBox(width: 8),
                      Text(
                        'Assign Roles',
                        style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                              fontWeight: FontWeight.bold,
                            ),
                      ),
                    ],
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    'Select roles to assign to ${employee.name}:',
                    style: Theme.of(context).textTheme.bodyMedium,
                  ),
                  SizedBox(height: 16),
                  Expanded(
                    child: ListView(
                      shrinkWrap: true,
                      children: availableRoles.map((role) {
                        return Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Row(
                              children: [
                                Expanded(
                                  child: CheckboxListTile(
                                    title: Text(role),
                                    value: selectedRoles.contains(role),
                                    onChanged: (bool? value) {
                                      setState(() {
                                        if (value == true) {
                                          selectedRoles.add(role);
                                        } else {
                                          selectedRoles.remove(role);
                                        }
                                      });
                                    },
                                  ),
                                ),
                                IconButton(
                                  icon: Icon(Icons.info_outline, color: Theme.of(context).colorScheme.primary),
                                  tooltip: 'View Permissions',
                                  onPressed: () {
                                    _showPermissionsPopup(context, rolePermissions[role]!);
                                  },
                                ),
                              ],
                            ),
                          ],
                        );
                      }).toList(),
                    ),
                  ),
                  SizedBox(height: 24),
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
                      icon: Icon(Icons.check),
                      label: Text('Assign'),
                      onPressed: () {
                        setState(() {
                          employee.roles.clear();
                          employee.roles.addAll(selectedRoles); // Update roles
                        });
                        Navigator.of(context).pop();
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ),
      );
    },
  );
}
void _showPermissionsPopup(BuildContext context, List<String> permissions) {
  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                'Permissions',
                style: Theme.of(context).textTheme.titleMedium?.copyWith(
                      fontWeight: FontWeight.bold,
                      color: Theme.of(context).colorScheme.primary,
                    ),
              ),
              SizedBox(height: 16),
              ...permissions.map((permission) {
                return Padding(
                  padding: const EdgeInsets.symmetric(vertical: 4.0),
                  child: Row(
                    children: [
                      Icon(Icons.check, size: 16, color: Theme.of(context).colorScheme.primary),
                      SizedBox(width: 8),
                      Expanded(
                        child: Text(
                          permission,
                          style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                                color: Theme.of(context).colorScheme.onSurfaceVariant,
                              ),
                        ),
                      ),
                    ],
                  ),
                );
              }).toList(),
              SizedBox(height: 16),
              Align(
                alignment: Alignment.centerRight,
                child: TextButton(
                  onPressed: () => Navigator.of(context).pop(),
                  child: Text('Close', style: TextStyle(color: Theme.of(context).colorScheme.primary)),
                ),
              ),
            ],
          ),
        ),
      );
    },
  );
}

void _showAssignRolesDialogv3(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: StatefulBuilder(
            builder: (BuildContext context, StateSetter setState) {
              return Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                      SizedBox(width: 8),
                      Text(
                        'Assign Roles',
                        style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                              fontWeight: FontWeight.bold,
                            ),
                      ),
                    ],
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    'Select roles to assign to ${employee.name}:',
                    style: Theme.of(context).textTheme.bodyMedium,
                  ),
                  SizedBox(height: 16),
                  Expanded(
                    child: ListView(
                      shrinkWrap: true,
                      children: availableRoles.map((role) {
                        return Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            CheckboxListTile(
                              title: Text(role),
                              value: selectedRoles.contains(role),
                              onChanged: (bool? value) {
                                setState(() {
                                  if (value == true) {
                                    selectedRoles.add(role);
                                  } else {
                                    selectedRoles.remove(role);
                                  }
                                });
                              },
                            ),
                            if (rolePermissions[role] != null)
                              Padding(
                                padding: const EdgeInsets.only(left: 16.0),
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: rolePermissions[role]!
                                      .map((permission) => Row(
                                            children: [
                                              Icon(Icons.check, size: 16, color: Theme.of(context).colorScheme.primary),
                                              SizedBox(width: 8),
                                              Text(permission),
                                            ],
                                          ))
                                      .toList(),
                                ),
                              ),
                          ],
                        );
                      }).toList(),
                    ),
                  ),
                  SizedBox(height: 24),
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
                      icon: Icon(Icons.check),
                      label: Text('Assign'),
                      onPressed: () {
                        setState(() {
                          employee.roles.clear();
                          employee.roles.addAll(selectedRoles); // Update roles
                        });
                        Navigator.of(context).pop();
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ),
      );
    },
  );
}


void _showAssignRolesDialogv2(BuildContext context, Employee employee) {
  List<String> availableRoles = rolePermissions.keys.toList();
  List<String> selectedRoles = List.from(employee.roles); // Copy current roles

  showDialog(
    context: context,
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(28.0),
        ),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: StatefulBuilder(
            builder: (BuildContext context, StateSetter setState) {
              return Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.primary, size: 32),
                      SizedBox(width: 8),
                      Text(
                        'Assign Roles',
                        style: Theme.of(context).textTheme.headlineSmall?.copyWith(
                              fontWeight: FontWeight.bold,
                            ),
                      ),
                    ],
                  ),
                  SizedBox(height: 16),
                  Divider(thickness: 1, color: Theme.of(context).colorScheme.onSurfaceVariant),
                  SizedBox(height: 16),
                  Text(
                    'Select roles to assign to ${employee.name}:',
                    style: Theme.of(context).textTheme.bodyMedium,
                  ),
                  SizedBox(height: 16),
                  Expanded(
                    child: ListView(
                      shrinkWrap: true,
                      children: availableRoles.map((role) {
                        return ExpansionTile(
                          title: Row(
                            children: [
                              Checkbox(
                                value: selectedRoles.contains(role),
                                onChanged: (bool? value) {
                                  setState(() {
                                    if (value == true) {
                                      selectedRoles.add(role);
                                    } else {
                                      selectedRoles.remove(role);
                                    }
                                  });
                                },
                              ),
                              Text(role),
                            ],
                          ),
                          children: rolePermissions[role]!
                              .map((permission) => Padding(
                                    padding: const EdgeInsets.only(left: 16.0),
                                    child: Row(
                                      children: [
                                        Icon(Icons.check, size: 16, color: Theme.of(context).colorScheme.primary),
                                        SizedBox(width: 8),
                                        Text(permission),
                                      ],
                                    ),
                                  ))
                              .toList(),
                        );
                      }).toList(),
                    ),
                  ),
                  SizedBox(height: 24),
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
                      icon: Icon(Icons.check),
                      label: Text('Assign'),
                      onPressed: () {
                        setState(() {
                          employee.roles.clear();
                          employee.roles.addAll(selectedRoles); // Update roles
                        });
                        Navigator.of(context).pop();
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ),
      );
    },
  );
}



@override
void initState() {
  super.initState();
  employees = getEmployeeData();
  employeeDataSource = EmployeeDataSource(
    context: context,
    employeeData: employees,
    onAssignRoles: (employee) {
      _showAssignRolesDialog(context, employee); // Pass the dialog logic
    },


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
                    ? 500.0
                    : screenWidth * 0.9; // 90% of the screen width for smaller screens
                final dialogHeight = screenHeight * 0.9;

                return ConstrainedBox(
                  constraints: BoxConstraints(
                    minWidth: 250, // Minimum width for the dialog
                    maxWidth: dialogWidth, // Maximum width for the dialog
                    minHeight: 300, // Minimum height for the dialog
                    maxHeight: dialogHeight, // Maximum height for the dialog
                  ),
                  child: Padding(
                    padding: const EdgeInsets.all(24.0),
                    child: SingleChildScrollView(
                      child: Column(
                        mainAxisSize: MainAxisSize.min,
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
Row(
  mainAxisAlignment: MainAxisAlignment.start, // Align items to the start
  crossAxisAlignment: CrossAxisAlignment.center, // Vertically center the items
  children: [
    Icon(Icons.person, color: Theme.of(context).colorScheme.primary, size: 32),
    SizedBox(width: 8), // Adjust spacing between the icon and text
    Text(
      'Employee Details',
      style: Theme.of(context).textTheme.headlineSmall?.copyWith(
            fontWeight: FontWeight.bold,
          ),
    ),
  ],
),                          SizedBox(height: 16),
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
                            children: [
                              _buildRolesAndPermissions(context, employee.roles, employee.permissions),
                            ],
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
Widget _buildRolesAndPermissions(
    BuildContext context, List<String> roles, List<String> permissions) {
  return ConstrainedBox(
    constraints: BoxConstraints(
      minWidth: double.infinity, // Matches the width of the dialog
      minHeight: 100, // Minimum height
      maxHeight: MediaQuery.of(context).size.height * 0.3, // Maximum height (30% of screen height)
    ),
    child: Scrollbar(
      thumbVisibility: true, // Always show the scrollbar thumb
      thickness: 6.0, // Thickness of the scrollbar
      radius: Radius.circular(8.0), // Rounded corners for the scrollbar
      child: ListView.builder(
        shrinkWrap: true, // Ensures the ListView takes only the required space
        physics: AlwaysScrollableScrollPhysics(), // Enables scrolling
        itemCount: permissions.length,
        itemBuilder: (context, index) {
          return Padding(
            padding: const EdgeInsets.symmetric(vertical: 4.0),
            child: Row(
              children: [
                Icon(Icons.check, color: Theme.of(context).colorScheme.primary, size: 20),
                SizedBox(width: 8),
                Expanded(
                  child: Text(
                    permissions[index],
                    style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                          color: Theme.of(context).colorScheme.onSurfaceVariant,
                        ),
                  ),
                ),
              ],
            ),
          );
        },
      ),
    ),
  );
}
Widget _buildDetailField(BuildContext context, String label, String? value) {
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
            value ?? 'N/A', // Fallback to 'N/A' if value is null
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



class EmployeeDataSource extends DataGridSource {
  final void Function(Employee) onView;
  final void Function(Employee) onAssignRoles; // Callback for opening the dialog
  final BuildContext context;

  EmployeeDataSource({
    required this.context,
    required List<Employee> employeeData,
    required this.onView,
    required this.onAssignRoles, // Accept the callback
  }) {
    _employeeData = employeeData.map<DataGridRow>(
      (employee) => DataGridRow(
        cells: [
          DataGridCell<int>(columnName: 'id', value: employee.id),
          DataGridCell<String>(columnName: 'name', value: employee.name),
          DataGridCell<String>(columnName: 'designation', value: employee.designation),
          DataGridCell<int>(columnName: 'salary', value: employee.salary),
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
          return Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              IconButton(
                icon: Icon(Icons.visibility, color: Theme.of(context).colorScheme.primary),
                tooltip: 'View Details',
                onPressed: () {
                  final employee = cell.value as Employee?;
                  if (employee != null) {
                    onView(employee);
                  }
                },
              ),
              IconButton(
                icon: Icon(Icons.assignment_ind, color: Theme.of(context).colorScheme.secondary),
                tooltip: 'Assign Roles',
                onPressed: () {
                  final employee = cell.value as Employee?;
                  if (employee != null) {
                    onAssignRoles(employee); // Use the callback
                  }
                },
              ),
            ],
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