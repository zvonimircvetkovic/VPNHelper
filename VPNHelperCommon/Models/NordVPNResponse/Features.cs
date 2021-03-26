using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNHelperCommon.Models
{
    public class Features
    {
        [JsonProperty("ikev2")]
        public bool Ikev2 { get; set; }

        [JsonProperty("openvpn_udp")]
        public bool OpenVPNUdp { get; set; }

        [JsonProperty("openvpn_tcp")]
        public bool OpenVPNTcp { get; set; }

        [JsonProperty("socks")]
        public bool Socks { get; set; }

        [JsonProperty("proxy")]
        public bool Proxy { get; set; }

        [JsonProperty("pptp")]
        public bool PPTP { get; set; }

        [JsonProperty("l2tp")]
        public bool L2TP { get; set; }

        [JsonProperty("openvpn_xor_udp")]
        public bool openVPNXorUDP { get; set; }

        [JsonProperty("openvpn_xor_tcp")]
        public bool OpenVPNXorTCP { get; set; }

        [JsonProperty("proxy_cybersec")]
        public bool ProxyCybersec { get; set; }

        [JsonProperty("proxy_ssl")]
        public bool ProxySSL { get; set; }

        [JsonProperty("proxy_ssl_cybersec")]
        public bool ProxySSLCybersec { get; set; }

        [JsonProperty("ikev2_v6")]
        public bool Ikev2v6 { get; set; }

        [JsonProperty("openvpn_udp_v6")]
        public bool openVPNUDPv6 { get; set; }

        [JsonProperty("openvpn_tcp_v6")]
        public bool openVPNTCPv6 { get; set; }

        [JsonProperty("wireguard_udp")]
        public bool WireguardUDP { get; set; }

        [JsonProperty("openvpn_udp_tls_crypt")]
        public bool openVPNUDPTLSCrypt { get; set; }

        [JsonProperty("openvpn_tcp_tls_crypt")]
        public bool OpenVPNTCPTLSCrypt { get; set; }

        [JsonProperty("openvpn_dedicated_udp")]
        public bool OpenVPNDedicatedUDP { get; set; }

        [JsonProperty("openvpn_dedicated_tcp")]
        public bool OpenVpnDedicatedTCP { get; set; }

        [JsonProperty("skylark")]
        public bool Skylark { get; set; }
    }
}
