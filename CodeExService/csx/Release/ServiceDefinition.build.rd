<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CodeExService" generation="1" functional="0" release="0" Id="8fc6ee8a-4002-4ca2-af69-9b3b6864f470" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CodeExServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="HoiioWCFService:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CodeExService/CodeExServiceGroup/LB:HoiioWCFService:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="HoiioWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CodeExService/CodeExServiceGroup/MapHoiioWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="HoiioWCFServiceInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CodeExService/CodeExServiceGroup/MapHoiioWCFServiceInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:HoiioWCFService:Endpoint1">
          <toPorts>
            <inPortMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFService/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapHoiioWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFService/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapHoiioWCFServiceInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFServiceInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="HoiioWCFService" generation="1" functional="0" release="0" software="C:\Users\Owner\documents\visual studio 2010\Projects\CodeExService\CodeExService\csx\Release\roles\HoiioWCFService" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;HoiioWCFService&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HoiioWCFService&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="WCFServiceWebRole1.svclog" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFServiceInstances" />
            <sCSPolicyFaultDomainMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFServiceFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="HoiioWCFServiceFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="HoiioWCFServiceInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="4a8ed820-91a4-4a17-8677-8d55d4c52ceb" ref="Microsoft.RedDog.Contract\ServiceContract\CodeExServiceContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="5c626537-f262-48bd-a19e-f3a5fa3f5634" ref="Microsoft.RedDog.Contract\Interface\HoiioWCFService:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFService:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>