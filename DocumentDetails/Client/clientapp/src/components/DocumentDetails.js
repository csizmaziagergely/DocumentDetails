import { useState, React } from 'react';
import '../App.css';
import { useNavigate, useParams } from "react-router-dom";
import { Button, Alert } from 'react-bootstrap';
import LoadingSpin from "react-loading-spin";
import { Table, Thead, Tbody, Tr, Th, Td } from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import useAxios from '../hooks/useAxios';

function DocumentDetails() {
    const axios = useAxios();
    const { id } = useParams();
	let childrenUrl = `/api/documents/${id}/children`;
	let eventsUrl = `/api/documents/${id}/events`;
    let navigate = useNavigate(); 

    function routeChange(documentId){ 
        let path = documentId.toString(); 
        navigate(`../documents/${path}`);
    }

    const { data: documentChildrenData, setData: setDocumentChildrenData, fetchError: childrenFetchError, isLoading: childrenIsLoading } = useAxiosFetchGet(childrenUrl);
    const { data: documentEventsData, setData: setDocumentEventsData, fetchError: eventsFetchError, isLoading: eventsIsLoading } = useAxiosFetchGet(eventsUrl);

  
    const forceUpdate = () => {
        setDocumentChildrenData([...documentChildrenData]);
        setDocumentEventsData([...documentEventsData]);
    }

    const renderDocument = (document) => {
        return (
        <Tr>
            <Td className="bordered clickable" onClick={() => routeChange(document.id)}>{document.title}</Td>
            <Td className="bordered">{document.extension}</Td>
            <Td className="bordered">{document.source}</Td>
        </Tr>
        )
    }
    const renderEvent = (event) => {
        return (
        <Tr>
            <Td className="bordered">{event.happenedAt}</Td>
            <Td className="bordered">{event.title}</Td>
        </Tr>
        )
    }
    return (<> 
    <h3>Related documents</h3>
    <Table>
      <Thead>
        <Tr>
          <Th className="bordered">Title</Th>
          <Th className="bordered">Extension</Th>
          <Th className="bordered">Source</Th>
        </Tr>
      </Thead>
      <Tbody>
        {documentChildrenData.map(renderDocument)}
        {childrenIsLoading && <h1><LoadingSpin /></h1>}
	    {childrenFetchError && <Alert variant='danger'>{childrenFetchError}</Alert>}
      </Tbody>
    </Table>
    <h3>Events</h3>
    <Table>
      <Thead>
        <Tr>
          <Th className="bordered">Date</Th>
          <Th className="bordered">Title</Th>
        </Tr>
      </Thead>
      <Tbody>
        {documentEventsData.map(renderEvent)}
        {eventsIsLoading && <h1><LoadingSpin /></h1>}
	    {eventsFetchError && <Alert variant='danger'>{eventsFetchError}</Alert>}
      </Tbody>
    </Table>
    <Button variant="secondary" onClick={() => navigate(-1)}>Go back to parent document</Button>
 </>);
}

export default DocumentDetails;