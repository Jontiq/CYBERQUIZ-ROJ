using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CYBERQUIZ.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResults_Questions_QuestionId",
                table: "UserResults");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserResults",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nätverkssäkerhet" },
                    { 2, "Kryptering" },
                    { 3, "Autentisering" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Brandväggar" },
                    { 2, 1, "VPN" },
                    { 3, 1, "DDoS-attacker" },
                    { 4, 2, "Symmetrisk kryptering" },
                    { 5, 2, "Asymmetrisk kryptering" },
                    { 6, 2, "Hashning" },
                    { 7, 3, "Lösenord" },
                    { 8, 3, "Tvåfaktorsautentisering" },
                    { 9, 3, "OAuth och SSO" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "SubCategoryId", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Vad är huvudsyftet med en brandvägg?" },
                    { 2, 1, "Vilket OSI-lager arbetar en paketfiltrerad brandvägg på?" },
                    { 3, 1, "Vad är en DMZ?" },
                    { 4, 1, "Vad är skillnaden mellan en stateful och stateless brandvägg?" },
                    { 5, 1, "Vad är en next-generation firewall (NGFW)?" },
                    { 6, 1, "Vilket påstående om brandväggsregler är korrekt?" },
                    { 7, 1, "Vad innebär 'default deny' i en brandväggspolicy?" },
                    { 8, 1, "Vad är en WAF?" },
                    { 9, 1, "Vilken typ av brandvägg inspekterar applikationslagret?" },
                    { 10, 1, "Vad menas med ingress- och egressfiltrering?" },
                    { 11, 2, "Vad står VPN för?" },
                    { 12, 2, "Vilket protokoll används ofta för VPN-tunnlar?" },
                    { 13, 2, "Vad är skillnaden mellan site-to-site och remote access VPN?" },
                    { 14, 2, "Vad är split tunneling i VPN?" },
                    { 15, 2, "Vilket protokoll kombinerar AH och ESP?" },
                    { 16, 2, "Vad är en VPN-koncentrator?" },
                    { 17, 2, "Vad innebär SSL/TLS VPN?" },
                    { 18, 2, "Vilket lager i OSI arbetar IPSec på?" },
                    { 19, 2, "Vad är WireGuard?" },
                    { 20, 2, "Vad är en no-log policy i VPN?" },
                    { 21, 3, "Vad står DDoS för?" },
                    { 22, 3, "Vad är ett botnet?" },
                    { 23, 3, "Vad är en SYN flood-attack?" },
                    { 24, 3, "Vad är amplification attack?" },
                    { 25, 3, "Hur skiljer sig DoS från DDoS?" },
                    { 26, 3, "Vad är rate limiting?" },
                    { 27, 3, "Vad är en CDN och hur hjälper det mot DDoS?" },
                    { 28, 3, "Vad innebär blackhole routing?" },
                    { 29, 3, "Vilken attacktyp översvämmar nätverket med UDP-paket?" },
                    { 30, 3, "Vad är scrubbing center?" },
                    { 31, 4, "Vilket är ett symmetriskt krypteringsalgoritm?" },
                    { 32, 4, "Hur många nycklar används vid symmetrisk kryptering?" },
                    { 33, 4, "Vad är nackdelen med symmetrisk kryptering?" },
                    { 34, 4, "Vad står AES för?" },
                    { 35, 4, "Vilken nyckellängd använder AES-256?" },
                    { 36, 4, "Vad är DES och varför används det inte längre?" },
                    { 37, 4, "Vad är ett block cipher?" },
                    { 38, 4, "Vad är ett stream cipher?" },
                    { 39, 4, "Vad är CBC-läge i kryptering?" },
                    { 40, 4, "Vad är Triple DES (3DES)?" },
                    { 41, 5, "Vilket är ett asymmetriskt krypteringsalgoritm?" },
                    { 42, 5, "Vad används den publika nyckeln till?" },
                    { 43, 5, "Vad används den privata nyckeln till?" },
                    { 44, 5, "Vad är PKI?" },
                    { 45, 5, "Vad är ett digitalt certifikat?" },
                    { 46, 5, "Vad är Diffie-Hellman?" },
                    { 47, 5, "Varför är asymmetrisk kryptering långsammare än symmetrisk?" },
                    { 48, 5, "Vad är ECC?" },
                    { 49, 5, "Vad är en digital signatur?" },
                    { 50, 5, "Vad är en CA (Certificate Authority)?" },
                    { 51, 6, "Vad är hashning?" },
                    { 52, 6, "Vilket av följande är en hashfunktion?" },
                    { 53, 6, "Vad är en kollision i hashning?" },
                    { 54, 6, "Vad är salting?" },
                    { 55, 6, "Varför används MD5 inte längre för lösenord?" },
                    { 56, 6, "Vad är bcrypt?" },
                    { 57, 6, "Vad är en regnbågstabell?" },
                    { 58, 6, "Vad är SHA-256?" },
                    { 59, 6, "Kan en hash reverseras?" },
                    { 60, 6, "Vad är HMAC?" },
                    { 61, 7, "Vad är ett starkt lösenord?" },
                    { 62, 7, "Vad är en lösenordshanterare?" },
                    { 63, 7, "Vad är credential stuffing?" },
                    { 64, 7, "Vad är en brute force-attack?" },
                    { 65, 7, "Vad är en dictionary attack?" },
                    { 66, 7, "Varför ska man inte återanvända lösenord?" },
                    { 67, 7, "Vad är NIST:s rekommendation för lösenordslängd?" },
                    { 68, 7, "Vad innebär lösenordsrotation?" },
                    { 69, 7, "Vad är ett passphrase?" },
                    { 70, 7, "Hur lagras lösenord säkert i en databas?" },
                    { 71, 8, "Vad är tvåfaktorsautentisering (2FA)?" },
                    { 72, 8, "Vilket är ett exempel på 2FA?" },
                    { 73, 8, "Vad är TOTP?" },
                    { 74, 8, "Vad är en hårdvarutoken?" },
                    { 75, 8, "Varför är SMS-baserad 2FA mindre säker?" },
                    { 76, 8, "Vad är en authenticator-app?" },
                    { 77, 8, "Vad är MFA?" },
                    { 78, 8, "Vad är en FIDO2-nyckel?" },
                    { 79, 8, "Vad är push-notifikationsautentisering?" },
                    { 80, 8, "Vad menas med 'something you know, something you have, something you are'?" },
                    { 81, 9, "Vad står OAuth för?" },
                    { 82, 9, "Vad är SSO?" },
                    { 83, 9, "Vad är skillnaden mellan autentisering och auktorisering?" },
                    { 84, 9, "Vad är ett access token i OAuth?" },
                    { 85, 9, "Vad är OpenID Connect?" },
                    { 86, 9, "Vad är SAML?" },
                    { 87, 9, "Vad är en refresh token?" },
                    { 88, 9, "Vad är OAuth 2.0 authorization code flow?" },
                    { 89, 9, "Vad är JWT?" },
                    { 90, 9, "Vad är en identity provider (IdP)?" }
                });

            migrationBuilder.InsertData(
                table: "AnswerOptions",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "Filtrera nätverkstrafik och blockera obehörig åtkomst" },
                    { 2, false, 1, "Öka internethastigheten" },
                    { 3, false, 1, "Kryptera all datatrafik" },
                    { 4, false, 1, "Lagra lösenord säkert" },
                    { 5, true, 2, "Lager 3 – Nätverkslagret" },
                    { 6, false, 2, "Lager 1 – Fysiska lagret" },
                    { 7, false, 2, "Lager 7 – Applikationslagret" },
                    { 8, false, 2, "Lager 5 – Sessionslagret" },
                    { 9, true, 3, "Ett mellannät som isolerar publika tjänster från det interna nätverket" },
                    { 10, false, 3, "En typ av kryptering" },
                    { 11, false, 3, "Ett protokoll för VPN" },
                    { 12, false, 3, "En metod för lösenordslagring" },
                    { 13, true, 4, "Stateful håller koll på anslutningens tillstånd, stateless gör det inte" },
                    { 14, false, 4, "De är identiska" },
                    { 15, false, 4, "Stateless är alltid säkrare" },
                    { 16, false, 4, "Stateful används bara för UDP" },
                    { 17, true, 5, "En brandvägg som även inspekterar applikationslagret och har IPS-funktioner" },
                    { 18, false, 5, "En brandvägg som bara filtrerar IP-adresser" },
                    { 19, false, 5, "En brandvägg utan loggning" },
                    { 20, false, 5, "En molnbaserad router" },
                    { 21, true, 6, "Regler utvärderas uppifrån och ner, första matchande regel gäller" },
                    { 22, false, 6, "Alla regler utvärderas alltid" },
                    { 23, false, 6, "Den sista regeln har högst prioritet" },
                    { 24, false, 6, "Regler gäller bara för inkommande trafik" },
                    { 25, true, 7, "All trafik blockeras som standard om ingen regel tillåter den" },
                    { 26, false, 7, "All trafik tillåts som standard" },
                    { 27, false, 7, "Bara utgående trafik blockeras" },
                    { 28, false, 7, "Brandväggen stängs av automatiskt" },
                    { 29, true, 8, "Web Application Firewall – skyddar webbapplikationer mot attacker som SQL injection" },
                    { 30, false, 8, "En trådlös brandvägg" },
                    { 31, false, 8, "En brandvägg för Windows" },
                    { 32, false, 8, "En VPN-koncentrator" },
                    { 33, true, 9, "Proxy-brandvägg" },
                    { 34, false, 9, "Paketfiltrerad brandvägg" },
                    { 35, false, 9, "Stateless brandvägg" },
                    { 36, false, 9, "Router" },
                    { 37, true, 10, "Ingress filtrerar inkommande trafik, egress filtrerar utgående trafik" },
                    { 38, false, 10, "De är samma sak" },
                    { 39, false, 10, "Ingress gäller bara för UDP" },
                    { 40, false, 10, "Egress filtrerar inkommande trafik" },
                    { 41, true, 11, "Virtual Private Network" },
                    { 42, false, 11, "Virtual Public Network" },
                    { 43, false, 11, "Verified Private Node" },
                    { 44, false, 11, "Virtual Protected Node" },
                    { 45, true, 12, "IPSec" },
                    { 46, false, 12, "HTTP" },
                    { 47, false, 12, "FTP" },
                    { 48, false, 12, "SMTP" },
                    { 49, true, 13, "Site-to-site kopplar samman nätverk, remote access kopplar enskilda användare" },
                    { 50, false, 13, "De är samma sak" },
                    { 51, false, 13, "Remote access kopplar samman nätverk" },
                    { 52, false, 13, "Site-to-site är snabbare" },
                    { 53, true, 14, "Delar upp trafiken så att bara viss trafik går via VPN" },
                    { 54, false, 14, "Krypterar all trafik dubbelt" },
                    { 55, false, 14, "Delar VPN-anslutningen mellan två användare" },
                    { 56, false, 14, "En metod för att öka hastigheten" },
                    { 57, true, 15, "IPSec" },
                    { 58, false, 15, "SSL" },
                    { 59, false, 15, "TLS" },
                    { 60, false, 15, "OpenVPN" },
                    { 61, true, 16, "En enhet som hanterar många VPN-anslutningar samtidigt" },
                    { 62, false, 16, "En router med inbyggd brandvägg" },
                    { 63, false, 16, "En krypteringsalgoritm" },
                    { 64, false, 16, "En typ av switch" },
                    { 65, true, 17, "VPN som använder SSL/TLS-protokollet och fungerar via webbläsare" },
                    { 66, false, 17, "VPN utan kryptering" },
                    { 67, false, 17, "VPN som bara fungerar på mobila enheter" },
                    { 68, false, 17, "En typ av brandvägg" },
                    { 69, true, 18, "Lager 3 – Nätverkslagret" },
                    { 70, false, 18, "Lager 4 – Transportlagret" },
                    { 71, false, 18, "Lager 7 – Applikationslagret" },
                    { 72, false, 18, "Lager 2 – Datalänklagret" },
                    { 73, true, 19, "Ett modernt, snabbt och enkelt VPN-protokoll" },
                    { 74, false, 19, "En brandväggstyp" },
                    { 75, false, 19, "En krypteringsalgoritm" },
                    { 76, false, 19, "En typ av router" },
                    { 77, true, 20, "VPN-leverantören sparar ingen information om användarens aktivitet" },
                    { 78, false, 20, "Loggar raderas efter 30 dagar" },
                    { 79, false, 20, "Alla anslutningar loggas men krypteras" },
                    { 80, false, 20, "Bara metadata sparas" },
                    { 81, true, 21, "Distributed Denial of Service" },
                    { 82, false, 21, "Direct Denial of Service" },
                    { 83, false, 21, "Dynamic Denial of Service" },
                    { 84, false, 21, "Distributed Data of Service" },
                    { 85, true, 22, "Ett nätverk av infekterade datorer som styrs av en angripare" },
                    { 86, false, 22, "En typ av brandvägg" },
                    { 87, false, 22, "En säker serverinfrastruktur" },
                    { 88, false, 22, "Ett VPN-nätverk" },
                    { 89, true, 23, "En attack som översvämmar servern med TCP SYN-paket utan att slutföra handskakningen" },
                    { 90, false, 23, "En attack mot DNS-servrar" },
                    { 91, false, 23, "En attack som krypterar filer" },
                    { 92, false, 23, "En attack mot lösenord" },
                    { 93, true, 24, "En attack som utnyttjar protokoll för att förstärka attacktrafiken mot målet" },
                    { 94, false, 24, "En attack som krypterar nätverkstrafik" },
                    { 95, false, 24, "En attack mot webbapplikationer" },
                    { 96, false, 24, "En attack som stjäl lösenord" },
                    { 97, true, 25, "DoS kommer från en källa, DDoS från många källor samtidigt" },
                    { 98, false, 25, "De är identiska" },
                    { 99, false, 25, "DDoS är alltid svagare" },
                    { 100, false, 25, "DoS kräver ett botnet" },
                    { 101, true, 26, "Begränsar antalet requests en användare kan göra under en tidsperiod" },
                    { 102, false, 26, "Ökar nätverkshastigheten" },
                    { 103, false, 26, "Krypterar nätverkstrafik" },
                    { 104, false, 26, "Blockerar alla utländska IP-adresser" },
                    { 105, true, 27, "CDN distribuerar trafiken över många servrar globalt vilket minskar effekten av DDoS" },
                    { 106, false, 27, "CDN krypterar all trafik" },
                    { 107, false, 27, "CDN blockerar alla utländska anslutningar" },
                    { 108, false, 27, "CDN ersätter brandväggen" },
                    { 109, true, 28, "Attacktrafik omdirigeras till en null-route och försvinner" },
                    { 110, false, 28, "All trafik krypteras" },
                    { 111, false, 28, "Servern stängs av automatiskt" },
                    { 112, false, 28, "Trafiken omdirigeras till en backup-server" },
                    { 113, true, 29, "UDP flood" },
                    { 114, false, 29, "SYN flood" },
                    { 115, false, 29, "HTTP flood" },
                    { 116, false, 29, "DNS amplification" },
                    { 117, true, 30, "En tjänst som filtrerar bort attacktrafik innan den når servern" },
                    { 118, false, 30, "En typ av brandvägg" },
                    { 119, false, 30, "En backup-datacenter" },
                    { 120, false, 30, "En DNS-server" },
                    { 121, true, 31, "AES" },
                    { 122, false, 31, "RSA" },
                    { 123, false, 31, "ECC" },
                    { 124, false, 31, "Diffie-Hellman" },
                    { 125, true, 32, "En nyckel" },
                    { 126, false, 32, "Två nycklar" },
                    { 127, false, 32, "Tre nycklar" },
                    { 128, false, 32, "Ingen nyckel" },
                    { 129, true, 33, "Nyckeln måste delas säkert mellan parterna" },
                    { 130, false, 33, "Den är för långsam" },
                    { 131, false, 33, "Den kräver två nycklar" },
                    { 132, false, 33, "Den kan inte kryptera stora filer" },
                    { 133, true, 34, "Advanced Encryption Standard" },
                    { 134, false, 34, "Advanced Encryption System" },
                    { 135, false, 34, "Asymmetric Encryption Standard" },
                    { 136, false, 34, "Authenticated Encryption Standard" },
                    { 137, true, 35, "256 bitar" },
                    { 138, false, 35, "128 bitar" },
                    { 139, false, 35, "512 bitar" },
                    { 140, false, 35, "64 bitar" },
                    { 141, true, 36, "DES har en för kort nyckel (56 bitar) och är lätt att knäcka med moderna datorer" },
                    { 142, false, 36, "DES är för komplicerat att implementera" },
                    { 143, false, 36, "DES stöds inte längre av moderna operativsystem" },
                    { 144, false, 36, "DES kräver för mycket minne" },
                    { 145, true, 37, "Krypterar data i fasta block av en viss storlek" },
                    { 146, false, 37, "Krypterar ett tecken i taget" },
                    { 147, false, 37, "Använder alltid 256-bitars nycklar" },
                    { 148, false, 37, "Är alltid snabbare än stream cipher" },
                    { 149, true, 38, "Krypterar data ett bit eller byte i taget" },
                    { 150, false, 38, "Krypterar data i block" },
                    { 151, false, 38, "Använder alltid asymmetrisk kryptering" },
                    { 152, false, 38, "Är alltid säkrare än block cipher" },
                    { 153, true, 39, "Cipher Block Chaining – varje block XORas med föregående krypterade block" },
                    { 154, false, 39, "En hashfunktion" },
                    { 155, false, 39, "En asymmetrisk krypteringsmetod" },
                    { 156, false, 39, "En typ av VPN-protokoll" },
                    { 157, true, 40, "Tillämpar DES-kryptering tre gånger för ökad säkerhet" },
                    { 158, false, 40, "En helt ny krypteringsalgoritm" },
                    { 159, false, 40, "Krypterar med tre olika algoritmer" },
                    { 160, false, 40, "Använder 768-bitars nycklar" },
                    { 161, true, 41, "RSA" },
                    { 162, false, 41, "AES" },
                    { 163, false, 41, "DES" },
                    { 164, false, 41, "Blowfish" },
                    { 165, true, 42, "Kryptera meddelanden som bara mottagaren kan dekryptera" },
                    { 166, false, 42, "Dekryptera meddelanden" },
                    { 167, false, 42, "Signera dokument" },
                    { 168, false, 42, "Lagra lösenord" },
                    { 169, true, 43, "Dekryptera meddelanden och signera digitalt" },
                    { 170, false, 43, "Kryptera meddelanden" },
                    { 171, false, 43, "Dela med alla" },
                    { 172, false, 43, "Skapa certifikat" },
                    { 173, true, 44, "Public Key Infrastructure – ett system för att hantera digitala certifikat och nycklar" },
                    { 174, false, 44, "En krypteringsalgoritm" },
                    { 175, false, 44, "Ett VPN-protokoll" },
                    { 176, false, 44, "En typ av brandvägg" },
                    { 177, true, 45, "Ett elektroniskt dokument som binder en publik nyckel till en identitet" },
                    { 178, false, 45, "En krypterad lösenordsfil" },
                    { 179, false, 45, "En typ av hashfunktion" },
                    { 180, false, 45, "En VPN-konfigurationsfil" },
                    { 181, true, 46, "Ett protokoll för säkert nyckelutbyte över ett osäkert nätverk" },
                    { 182, false, 46, "En symmetrisk krypteringsalgoritm" },
                    { 183, false, 46, "En hashfunktion" },
                    { 184, false, 46, "En typ av brandvägg" },
                    { 185, true, 47, "Matematiska operationer med stora primtal är beräkningstungt" },
                    { 186, false, 47, "Den använder längre nycklar alltid" },
                    { 187, false, 47, "Den kräver mer minne" },
                    { 188, false, 47, "Den krypterar mer data per operation" },
                    { 189, true, 48, "Elliptic Curve Cryptography – asymmetrisk kryptering med kortare nycklar och hög säkerhet" },
                    { 190, false, 48, "En symmetrisk krypteringsalgoritm" },
                    { 191, false, 48, "En hashfunktion" },
                    { 192, false, 48, "En typ av VPN" },
                    { 193, true, 49, "En kryptografisk mekanism som verifierar avsändarens identitet och meddelandets integritet" },
                    { 194, false, 49, "En elektronisk namnteckning i ett Word-dokument" },
                    { 195, false, 49, "En typ av lösenord" },
                    { 196, false, 49, "En hashfunktion" },
                    { 197, true, 50, "En betrodd organisation som utfärdar och signerar digitala certifikat" },
                    { 198, false, 50, "En krypteringsalgoritm" },
                    { 199, false, 50, "En typ av brandvägg" },
                    { 200, false, 50, "En DNS-server" },
                    { 201, true, 51, "En envägsfunktion som omvandlar data till ett fast värde av bestämd längd" },
                    { 202, false, 51, "En krypteringsmetod med nyckel" },
                    { 203, false, 51, "En metod för att komprimera filer" },
                    { 204, false, 51, "En typ av VPN" },
                    { 205, true, 52, "SHA-256" },
                    { 206, false, 52, "AES" },
                    { 207, false, 52, "RSA" },
                    { 208, false, 52, "DES" },
                    { 209, true, 53, "När två olika indata ger samma hashvärde" },
                    { 210, false, 53, "När en hash kan dekrypteras" },
                    { 211, false, 53, "När hashfunktionen kraschar" },
                    { 212, false, 53, "När salt-värdet är fel" },
                    { 213, true, 54, "Lägga till ett slumpmässigt värde till lösenordet innan hashning" },
                    { 214, false, 54, "Kryptera hashen en extra gång" },
                    { 215, false, 54, "Lagra lösenordet i klartext" },
                    { 216, false, 54, "Använda ett längre lösenord" },
                    { 217, true, 55, "MD5 är kollisionsdrabbad och för snabb vilket gör den osäker för lösenord" },
                    { 218, false, 55, "MD5 är för långsam" },
                    { 219, false, 55, "MD5 stöds inte längre av operativsystem" },
                    { 220, false, 55, "MD5 kräver för mycket minne" },
                    { 221, true, 56, "En lösenordshashfunktion med inbyggt salt och konfigurerbar kostnadsfaktor" },
                    { 222, false, 56, "En symmetrisk krypteringsalgoritm" },
                    { 223, false, 56, "En typ av VPN-protokoll" },
                    { 224, false, 56, "En hashfunktion för filer" },
                    { 225, true, 57, "En förberäknad tabell med hashvärden för att knäcka lösenord" },
                    { 226, false, 57, "En tabell med krypterade lösenord" },
                    { 227, false, 57, "En typ av brandväggsregel" },
                    { 228, false, 57, "En metod för nyckelutbyte" },
                    { 229, true, 58, "En kryptografisk hashfunktion som producerar ett 256-bitars hashvärde" },
                    { 230, false, 58, "En symmetrisk krypteringsalgoritm" },
                    { 231, false, 58, "En asymmetrisk krypteringsalgoritm" },
                    { 232, false, 58, "En VPN-protokoll" },
                    { 233, true, 59, "Nej, hashning är en envägsfunktion som inte kan reverseras" },
                    { 234, false, 59, "Ja, med rätt nyckel" },
                    { 235, false, 59, "Ja, med tillräcklig datorkraft" },
                    { 236, false, 59, "Ja, om salt-värdet är känt" },
                    { 237, true, 60, "Hash-based Message Authentication Code – verifierar meddelandets integritet och äkthet" },
                    { 238, false, 60, "En krypteringsalgoritm" },
                    { 239, false, 60, "En typ av digitalt certifikat" },
                    { 240, false, 60, "En VPN-protokoll" },
                    { 241, true, 61, "Minst 12 tecken med stora/små bokstäver, siffror och specialtecken" },
                    { 242, false, 61, "Ditt namn och födelseår" },
                    { 243, false, 61, "Ett ord från en ordbok" },
                    { 244, false, 61, "Samma lösenord på alla sidor" },
                    { 245, true, 62, "Ett program som lagrar och genererar starka lösenord säkert" },
                    { 246, false, 62, "En webbläsartillägg för autofyll" },
                    { 247, false, 62, "En anteckningsbok för lösenord" },
                    { 248, false, 62, "En typ av 2FA" },
                    { 249, true, 63, "Att använda stulna användarnamn/lösenord från en dataintrång på andra tjänster" },
                    { 250, false, 63, "En brute force-attack" },
                    { 251, false, 63, "En phishing-attack" },
                    { 252, false, 63, "En attack mot lösenordshashar" },
                    { 253, true, 64, "Systematiskt prova alla möjliga kombinationer tills rätt lösenord hittas" },
                    { 254, false, 64, "Gissa lösenord med hjälp av personlig information" },
                    { 255, false, 64, "Använda förberäknade hashvärden" },
                    { 256, false, 64, "Avlyssna nätverkstrafik" },
                    { 257, true, 65, "En attack som provar ord från en ordlista som potentiella lösenord" },
                    { 258, false, 65, "En attack som provar alla möjliga kombinationer" },
                    { 259, false, 65, "En attack mot ordbokssidor" },
                    { 260, false, 65, "En attack med stulna lösenord" },
                    { 261, true, 66, "Om ett lösenord stjäls kan angriparen komma åt alla konton med samma lösenord" },
                    { 262, false, 66, "Det är svårare att komma ihåg" },
                    { 263, false, 66, "Det strider mot GDPR" },
                    { 264, false, 66, "Det gör inloggning långsammare" },
                    { 265, true, 67, "Minst 8 tecken, rekommenderat 15+ tecken" },
                    { 266, false, 67, "Exakt 8 tecken" },
                    { 267, false, 67, "Minst 20 tecken alltid" },
                    { 268, false, 67, "Längden spelar ingen roll" },
                    { 269, true, 68, "Regelbundet byta lösenord för att minska risken vid ett intrång" },
                    { 270, false, 68, "Använda samma lösenord på rotation" },
                    { 271, false, 68, "Automatisk inloggning" },
                    { 272, false, 68, "En typ av 2FA" },
                    { 273, true, 69, "En serie av slumpmässiga ord som används som lösenord" },
                    { 274, false, 69, "Ett lösenord med specialtecken" },
                    { 275, false, 69, "En PIN-kod" },
                    { 276, false, 69, "Ett engångslösenord" },
                    { 277, true, 70, "Hashas med salt med en algoritm som bcrypt eller Argon2" },
                    { 278, false, 70, "Lagras i klartext" },
                    { 279, false, 70, "Krypteras med AES" },
                    { 280, false, 70, "Lagras i en separat databas utan kryptering" },
                    { 281, true, 71, "En inloggningsmetod som kräver två olika typer av verifiering" },
                    { 282, false, 71, "Att logga in med två lösenord" },
                    { 283, false, 71, "En metod för att återställa lösenord" },
                    { 284, false, 71, "Att använda två olika webbläsare" },
                    { 285, true, 72, "Lösenord + engångskod via SMS" },
                    { 286, false, 72, "Användarnamn + lösenord" },
                    { 287, false, 72, "E-post + användarnamn" },
                    { 288, false, 72, "PIN-kod + PIN-kod" },
                    { 289, true, 73, "Time-based One-Time Password – engångslösenord som är giltigt i en kort tid" },
                    { 290, false, 73, "En typ av VPN" },
                    { 291, false, 73, "En krypteringsalgoritm" },
                    { 292, false, 73, "En hashfunktion" },
                    { 293, true, 74, "En fysisk enhet som genererar engångslösenord" },
                    { 294, false, 74, "En USB-minnesenhet" },
                    { 295, false, 74, "En typ av smartkort" },
                    { 296, false, 74, "En biometrisk sensor" },
                    { 297, true, 75, "SMS kan avlyssnas via SIM-swapping eller SS7-sårbarheter" },
                    { 298, false, 75, "SMS är för långsamt" },
                    { 299, false, 75, "SMS kräver internetanslutning" },
                    { 300, false, 75, "SMS-koder är för korta" },
                    { 301, true, 76, "En app som genererar TOTP-koder för 2FA, t.ex. Google Authenticator" },
                    { 302, false, 76, "En lösenordshanterare" },
                    { 303, false, 76, "En VPN-klient" },
                    { 304, false, 76, "En antivirusprogram" },
                    { 305, true, 77, "Multi-Factor Authentication – inloggning med fler än två faktorer" },
                    { 306, false, 77, "Samma som 2FA" },
                    { 307, false, 77, "En typ av VPN" },
                    { 308, false, 77, "En krypteringsmetod" },
                    { 309, true, 78, "En hårdvarunyckel för lösenordsfri autentisering baserad på publik nyckelkryptering" },
                    { 310, false, 78, "En typ av lösenordshanterare" },
                    { 311, false, 78, "En VPN-nyckel" },
                    { 312, false, 78, "En krypteringsalgoritm" },
                    { 313, true, 79, "En 2FA-metod där användaren godkänner inloggning via en notifikation i en app" },
                    { 314, false, 79, "En SMS-baserad 2FA" },
                    { 315, false, 79, "En e-postbaserad verifiering" },
                    { 316, false, 79, "En biometrisk autentisering" },
                    { 317, true, 80, "De tre kategorierna av autentiseringsfaktorer: kunskap, ägande och biometri" },
                    { 318, false, 80, "Tre typer av lösenord" },
                    { 319, false, 80, "Tre nivåer av kryptering" },
                    { 320, false, 80, "Tre typer av VPN" },
                    { 321, true, 81, "Open Authorization – ett protokoll för säker delegerad åtkomst" },
                    { 322, false, 81, "Open Authentication" },
                    { 323, false, 81, "Online Authorization" },
                    { 324, false, 81, "Optional Authentication" },
                    { 325, true, 82, "Single Sign-On – logga in en gång och få åtkomst till flera tjänster" },
                    { 326, false, 82, "Secure Sign-On" },
                    { 327, false, 82, "Simple Sign-Out" },
                    { 328, false, 82, "En typ av 2FA" },
                    { 329, true, 83, "Autentisering verifierar vem du är, auktorisering avgör vad du får göra" },
                    { 330, false, 83, "De är samma sak" },
                    { 331, false, 83, "Auktorisering verifierar vem du är" },
                    { 332, false, 83, "Autentisering avgör vad du får göra" },
                    { 333, true, 84, "En tidsbegränsad nyckel som ger åtkomst till en resurs utan att dela lösenordet" },
                    { 334, false, 84, "Ett permanent lösenord" },
                    { 335, false, 84, "En krypteringsnyckel" },
                    { 336, false, 84, "En typ av certifikat" },
                    { 337, true, 85, "Ett identitetslager ovanpå OAuth 2.0 för autentisering" },
                    { 338, false, 85, "En ersättare för SAML" },
                    { 339, false, 85, "En krypteringsalgoritm" },
                    { 340, false, 85, "En typ av VPN" },
                    { 341, true, 86, "Security Assertion Markup Language – ett XML-baserat protokoll för SSO" },
                    { 342, false, 86, "En krypteringsstandard" },
                    { 343, false, 86, "En hashfunktion" },
                    { 344, false, 86, "En typ av brandvägg" },
                    { 345, true, 87, "En långlivad token som används för att hämta nya access tokens" },
                    { 346, false, 87, "En token som förnyar lösenordet" },
                    { 347, false, 87, "En engångstoken" },
                    { 348, false, 87, "En krypteringsnyckel" },
                    { 349, true, 88, "En OAuth-flöde där en kod utbyts mot tokens via en säker backend-kanal" },
                    { 350, false, 88, "En inloggningsmetod med användarnamn och lösenord" },
                    { 351, false, 88, "En typ av 2FA" },
                    { 352, false, 88, "En krypteringsmetod" },
                    { 353, true, 89, "JSON Web Token – ett kompakt tokenformat för säker informationsöverföring" },
                    { 354, false, 89, "Java Web Token" },
                    { 355, false, 89, "En krypteringsalgoritm" },
                    { 356, false, 89, "En typ av certifikat" },
                    { 357, true, 90, "En tjänst som hanterar och verifierar användaridentiteter, t.ex. Google eller Microsoft" },
                    { 358, false, 90, "En typ av brandvägg" },
                    { 359, false, 90, "En krypteringsalgoritm" },
                    { 360, false, 90, "En DNS-server" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserResults_UserId",
                table: "UserResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResults_Questions_QuestionId",
                table: "UserResults",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResults_Questions_QuestionId",
                table: "UserResults");

            migrationBuilder.DropIndex(
                name: "IX_UserResults_UserId",
                table: "UserResults");

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserResults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResults_Questions_QuestionId",
                table: "UserResults",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
