import { useState, React } from 'react';
import '../App.css';
import { useNavigate, useParams } from "react-router-dom";
import { Button, Alert, Form } from 'react-bootstrap';
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
    const [isFiltered, setIsFiltered] = useState(false);
    const [filteredDocumentData, setFilteredDocumentData] = useState([]);

    function routeChange(documentId){ 
        let path = documentId.toString(); 
        navigate(`../documents/${path}`);
    }

    const changeFilter = (e) => {
        e.preventDefault();
        setIsFiltered(true);
        setFilteredDocumentData(documentChildrenData.filter(document => document.title.toLowerCase().includes(e.target.value.toLowerCase())));
    }

    const { data: documentChildrenData, setData: setDocumentChildrenData, fetchError: childrenFetchError, isLoading: childrenIsLoading } = useAxiosFetchGet(childrenUrl);
    const { data: documentEventsData, setData: setDocumentEventsData, fetchError: eventsFetchError, isLoading: eventsIsLoading } = useAxiosFetchGet(eventsUrl);

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
    {documentChildrenData.length>0 && <>
    <Form>
      <Form.Control type="text" placeholder="Type to filter by title..." onChange={(e) => changeFilter(e)}/>
    </Form>
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
        {isFiltered ? (filteredDocumentData.map(renderDocument)) : (documentChildrenData.map(renderDocument))}
      </Tbody>
    </Table>
    {childrenIsLoading && <h1><LoadingSpin /></h1>}
	{childrenFetchError && <Alert variant='danger'>{childrenFetchError}</Alert>}
    </>}
    
    {documentEventsData.length>0 && <>
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
        
      </Tbody>
    </Table>
    {eventsIsLoading && <h1><LoadingSpin /></h1>}
	{eventsFetchError && <Alert variant='danger'>{eventsFetchError}</Alert>}
    </>}
    <Button variant="secondary" onClick={() => navigate(-1)}>Go back to parent document</Button>
 </>);
}

export default DocumentDetails;