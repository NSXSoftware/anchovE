# NSX Software
# anchovE
## Description

This is a command-line tool with multiple functionalities, including backdoor scanning, web shell injection, and library management. The tool also allows the user to select a specific attack type and even load libraries to help expand your attacks.

## Dependencies

- Spectre.Console
- System
- System.Net
- System.IO
- System.Data

## Usage

To use the tool, you can run the program in the command line, and it will display a banner and a prompt asking you to select an attack type. The available options are:

- Backdoor Builder
- Backdoor Scanner
- Web Shell
- Servers
- History
- Backdoor Injector
- Library

Depending on the attack type you select, the tool will ask you for additional information, such as the target URL and backdoor hash for the Web Shell attack. After providing the necessary input, the tool will perform the selected action and provide the results.

### Backdoor Scanner

If you choose the "Backdoor Scanner" option, the tool will prompt you to enter the target URL. Once you provide the URL, the tool will display the message "Loading Files" and "Scanning" with the target URL. After the tool will scan the URL or Input for places where an backdoor could be injected using SQL,XSS,RCE, and more

### Web Shell

If you select the "Web Shell" option, the tool will prompt you to enter the target URL and backdoor hash. Then, you need to select the type of backdoor detection, either POST or GET. After providing the necessary information, the tool will display the message "Scanning" with the target URL. If the backdoor is found, the tool will display a message indicating that the backdoor is found on the target URL and provide you with a shell prompt. You can input shell commands, and the tool will execute them on the target system. If an error occurs, the tool will display an error message.

### Library

If you choose the "Library" option, the tool will allow you to manage your libraries. You can add, remove, or view your libraries. When adding a library, you need to provide the library name and description. If you choose to remove a library, the tool will prompt you to select the library to remove from the list of available libraries.

## Contributions

The NSX Software team created this tool. If you have any suggestions or want to contribute to the tool, please contact us at nsxsoftware@nsxsoftware.com.

## License

This tool is licensed under the MIT license. You can view the license file in the project repository.
