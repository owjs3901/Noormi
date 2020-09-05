#include "network.h"

#include <tizen.h>
#include <service_app.h>
#include <string.h>
#include <stdlib.h>
#include <stdint.h>
#include "log.h"
#include "resource/resource_infrared_motion.h"
#include "resource/resource_led.h"

void connect_server(){
	_I("server connect");
	int sock;
	int retval;
	char buf[BUFSIZE];
	struct hostent *remoteHost;			//웹주소를 ip로 바꾸기 위해

	sock = socket(AF_INET, SOCK_STREAM, 0);
	if (sock < 0)
		return;
	remoteHost = gethostbyname("mbs-b.com"); //웹주소를 ip로 바꾸기 위해

	struct sockaddr_in client_addr;

	client_addr.sin_family = AF_INET;
	client_addr.sin_port = htons(3000);
	client_addr.sin_addr.s_addr = inet_addr(inet_ntoa(*(struct in_addr *)remoteHost->h_addr_list[0]));
	retval = connect(sock, (struct sockaddr *)&client_addr, sizeof(client_addr));

	_I("_>>>%s", inet_ntoa(*(struct in_addr *)remoteHost->h_addr_list[0]));
	if (retval < 0)
	{
		printf("NOT connect!!!!!");
		return;
	}

	char msg[500] = "GET /api/devices/cost HTTP/1.1\r\n";
	strcat(msg, "Host: mbs-b.com:3000\r\n\r\n");

	send(sock, msg, strlen(msg), 0);


	while (read(sock, buf, BUFSIZE) > 0)
	{
		puts(buf);
		memset(buf, 0, BUFSIZE);
	}
	close(sock);
	return;
}
